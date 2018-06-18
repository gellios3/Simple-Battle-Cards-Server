using System;
using System.Collections.Generic;
using System.Linq;
using Server.Interfaces;
using Server.Signals;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

namespace Server
{
    public class GameServerService : IServer
    {

        [Inject] public ServerConnectedSignal ServerConnectedSignal { get; set; }
        
        public event Action<string> OnServerError = delegate { };
        public event Action<bool> OnServerDisconnect = delegate { };

        public void StartServer(int port)
        {
            NetworkServer.Listen(port);
            Debug.Log("Start listening server on port " + port);
        }

        public void Restart(int port)
        {
            Shutdown();
            StartServer(port);
        }

        public void Shutdown()
        {
            NetworkServer.Shutdown();
            Debug.Log("Stop server");
        }

        public void OnConnectToServer(NetworkMessage msg)
        {
            ServerConnectedSignal.Dispatch(true);
        }

        public void OnDisconnectFromServer(NetworkMessage msg)
        {
            OnServerDisconnect(true);
        }

        public void OnServerErrorMethod(NetworkMessage msg)
        {
            var error = msg.ReadMessage<ErrorMessage>();
            OnServerError(error.ToString());
        }

        public void Send(IEnumerable<int> connectionId, short msgType, MessageBase msg)
        {
            NetworkServer.SendToAll(msgType, msg);
        }

        public void RegisterFeatureHandlers(IEnumerable<IServerFeature> handlers)
        {
            foreach (var handler in handlers)
            {
                foreach (var serverHandler in handler.Handlers())
                {
                    NetworkServer.RegisterHandler(serverHandler.MessageType, serverHandler.Handle);
                }
            }
        }

        public IEnumerable<int> ActiveConnections
        {
            get
            {
                var connections = NetworkServer.connections;
                var intConnection = connections.Select(p => p.connectionId);
                return intConnection;
            }
        }
    }
}