﻿using System.Collections.Generic;
using Client.Interfaces;
using Client.Signals;
using UnityEngine;
using UnityEngine.Networking;

namespace Client
{
    public class ServerConnectorService : IServerConnector
    {
        /// <summary>
        /// Server url
        /// </summary>
        private const string Url = "localhost";

        private const int Port = 45555;

        private NetworkClient _client;

        /// <summary>
        /// Get server data handler
        /// </summary>
//        [Inject]public GetServerRegularRoomHandler GetServerRegularRoomHandler { get; set; }

//        [Inject] public GetServerSuperRoomHandler GetServerSuperRoomHandler { get; set; }

        [Inject] public DisonnectedFromServerSignal DisonnectedFromServerSignal { get; set; }

        [Inject] public ServerConnectedResultSignal ServerConnectedResultSignal { get; set; }

        public void Connect()
        {
            _client = new NetworkClient();
            _client.Connect(Url, Port);
            _client.RegisterHandler(MsgType.Connect, msg => { ServerConnectedResultSignal.Dispatch(true); });
//            RegisterHandlers(new List<IServerMessageHandler> {GetServerRegularRoomHandler, GetServerSuperRoomHandler});
        }

        public void DisconectFromServer()
        {
            if (_client != null)
            {
                _client.Disconnect();
                DisonnectedFromServerSignal.Dispatch(true);
            }
            else
            {
                Debug.LogError("You should connect to server first");
            }
        }

        public void Send(short msgId, MessageBase msg)
        {
            if (_client != null && _client.isConnected)
            {
                _client.Send(msgId, msg);
            }
            else
            {
                Debug.LogError("You should connect to server first");
            }
        }

        public void RegisterHandlers(IEnumerable<IServerMessageHandler> handlers)
        {
            foreach (var handler in handlers)
            {
                _client.RegisterHandler(handler.MessageType, handler.Handle);
            }
        }
    }
}