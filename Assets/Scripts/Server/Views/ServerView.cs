using System.Collections.Generic;
using System.Text;
using Models.RegularGame;
using strange.extensions.mediation.impl;
using Server.Models;
using Server.Signals;
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

        [Inject] public StartServerSignal StartServerSignal { get; set; }

        /// <summary>
        /// Server port
        /// </summary>
        private int _serverPort = 45555;

        /// <summary>
        /// SErver status
        /// </summary>
        private string _serverStatus = "disconnected";

        /// <summary>
        /// Server errors
        /// </summary>
        private readonly List<string> _serverErrors = new List<string>();

        /// <summary>
        /// On enable view
        /// </summary>
        private void OnEnable()
        {
            _posrtField.text = _serverPort.ToString();
            // on end edit save port
            _posrtField.onEndEdit.AddListener(delegate
            {
                _serverPort = int.TryParse(_posrtField.text, out _serverPort) ? _serverPort : 45555;
                _posrtField.text = _serverPort.ToString();
            });

            // add buttons on click events
            _startButton.OnClickAsObservable().Subscribe(p => { StartServerSignal.Dispatch(_serverPort); });
            _restartButton.OnClickAsObservable().Subscribe(p => { GameServerService.Restart(_serverPort); });
            _stopButton.OnClickAsObservable().Subscribe(p => { GameServerService.Shutdown(); });
        }

        /// <summary>
        /// Update view
        /// </summary>
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

        /// <summary>
        /// Init text log
        /// </summary>
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


        /// <summary>
        /// On change status
        /// </summary>
        /// <param name="str"></param>
        public void ChangeStatus(string str)
        {
            _serverStatus = str;
        }

        /// <summary>
        /// Add server errors
        /// </summary>
        /// <param name="errorMsg"></param>
        public void OnGameServerError(string errorMsg)
        {
            _serverErrors.Add(errorMsg);
        }
    }


    /// <summary>
    /// Server view mediator
    /// </summary>
    public class ServerViewMediator : TargetMediator<ServerView>
    {
        /// <summary>
        /// Server connected signal
        /// </summary>
        [Inject]
        public ServerConnectedSignal ServerConnectedSignal { get; set; }

        /// <summary>
        /// Disconnect server signal
        /// </summary>
        [Inject]
        public DisconnectSignal DisconnectSignal { get; set; }

        /// <summary>
        /// On sever error 
        /// </summary>
        [Inject]
        public ServerErrorSignal ServerErrorSignal { get; set; }

        /// <summary>
        /// On register
        /// </summary>
        public override void OnRegister()
        {
            ServerConnectedSignal.AddListener(success =>
            {
                View.ChangeStatus(success ? "Connected" : "Connected Error!");
            });
            DisconnectSignal.AddListener(success =>
            {
                View.ChangeStatus(success ? "Disconnected" : "Disconnected Error!");
            });
            ServerErrorSignal.AddListener(View.OnGameServerError);
        }
    }
}