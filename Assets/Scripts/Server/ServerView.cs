using System.Collections.Generic;
using System.Text;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Server
{
    public class ServerView : MonoBehaviour
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
        /// 
        /// </summary>
        private NetworkingGameServer _gameServer;
        private int _serverPort = 45555;
        private string _serverStatus = "disconnected";
        private readonly List<string> _serverErrors = new List<string>();

        private void Awake()
        {
            _gameServer = GetComponent<NetworkingGameServer>();
            _gameServer.OnServerConnected += OnGameServerConnected;
            _gameServer.OnServerDisconnect += OnGameServerDisconnected;
            _gameServer.OnServerError += OnGameServerError;
        }

        private void OnEnable()
        {
            _posrtField.text = _serverPort.ToString();
            _posrtField.onEndEdit.AddListener(delegate
            {
                _serverPort = int.TryParse(_posrtField.text, out _serverPort) ? _serverPort : 45555;
                _posrtField.text = _serverPort.ToString();
            });
            _startButton.OnClickAsObservable().Subscribe(p => { _gameServer.StartServer(_serverPort); });
            _restartButton.OnClickAsObservable().Subscribe(p => { _gameServer.Restart(_serverPort); });
            _stopButton.OnClickAsObservable().Subscribe(p => { _gameServer.Shutdown(); });
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


        private void OnGameServerConnected(bool success)
        {
            _serverStatus = "connected";
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
}