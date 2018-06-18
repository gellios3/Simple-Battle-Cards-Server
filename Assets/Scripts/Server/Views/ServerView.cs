using System.Collections.Generic;
using System.Text;
using Models;
using strange.extensions.mediation.impl;
using Server.Signals;
using Signals;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using View;

namespace Server.Views
{
    public class ServerView : EventView
    {
        /// <summary>
        /// Port field
        /// </summary>
        [SerializeField] private InputField _posrtField;

        /// <summary>
        /// Start server button
        /// </summary>
        [SerializeField] private Button _startButton;

        /// <summary>
        /// Stop server button
        /// </summary>
        [SerializeField] private Button _stopButton;

        /// <summary>
        /// Restart server button
        /// </summary>
        [SerializeField] private Button _restartButton;

        /// <summary>
        /// Log text
        /// </summary>
        [SerializeField] private Text _logText;
        
        /// <summary>
        /// Networking game server
        /// </summary>
        [Inject]
        public GameServerService GameServerService { get; set; }

        private int _serverPort = 45555;
        private string _serverStatus = "disconnected";
        private readonly List<string> _serverErrors = new List<string>();

        private void OnEnable()
        {
            _posrtField.text = _serverPort.ToString();
            _posrtField.onEndEdit.AddListener(delegate
            {
                _serverPort = int.TryParse(_posrtField.text, out _serverPort) ? _serverPort : 45555;
                _posrtField.text = _serverPort.ToString();
            });
            _startButton.OnClickAsObservable().Subscribe(p => { GameServerService.StartServer(_serverPort); });
            _restartButton.OnClickAsObservable().Subscribe(p => { GameServerService.Restart(_serverPort); });
            _stopButton.OnClickAsObservable().Subscribe(p => { GameServerService.Shutdown(); });
        }

        private void Update()
        {
            if (!NetworkServer.active)
            {
                _startButton.gameObject.SetActive(true);
                _stopButton.gameObject.SetActive(false);
                _restartButton.gameObject.SetActive(false);
                _logText.gameObject.SetActive(false);
            }
            else
            {
                _startButton.gameObject.SetActive(false);
                _stopButton.gameObject.SetActive(true);
                _restartButton.gameObject.SetActive(true);
                _logText.gameObject.SetActive(true);

                InitLog();
            }
        }

        private void InitLog()
        {
            var textBulder = new StringBuilder();
            textBulder.AppendLine("Server status:" + _serverStatus);
            textBulder.AppendLine("Server Errors: \n");

            foreach (var serverError in _serverErrors)
            {
                textBulder.AppendLine(serverError);
                Debug.LogError(serverError);
            }

            _logText.text = textBulder.ToString();
        }


        public void ChangeStatus(string str)
        {
            _serverStatus = str;
        }

        private void OnGameServerDisconnected(bool succes)
        {
            _serverStatus = "disconnected";
        }

        private void OnGameServerError(string errorMsg)
        {
            _serverErrors.Add(errorMsg);
        }
    }


    /// <summary>
    /// Server view mediator
    /// </summary>
    public class ServerViewMediator : TargetMediator<ServerView>
    {
        
        [Inject] public ServerConnectedSignal ServerConnectedSignal { get; set; }

        public override void OnRegister()
        {
            ServerConnectedSignal.AddListener(OnGameServerConnected);
//            GameServer.OnServerDisconnect += OnGameServerDisconnected;
//            GameServer.OnServerError += OnGameServerError;
        }

        private void OnGameServerConnected(bool success)
        {
            View.ChangeStatus(success ? "Connected" : "Connected Error!");
        }
    }
}