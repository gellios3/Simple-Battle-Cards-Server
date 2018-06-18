using System;
using System.Collections.Generic;
using UnityEngine.Networking;

namespace Server.Interfaces
{
    public interface IServer
    {
        void StartServer(int port);
        void Restart(int port);
        void Shutdown();

        void Send(IEnumerable<int> connectionId, short msgType, MessageBase msg);
        void RegisterFeatureHandlers(IEnumerable<IServerFeature> handlers);

//        event Action<bool> OnServerConnected;
        
        event Action<string> OnServerError;
        event Action<bool> OnServerDisconnect;

        IEnumerable<int> ActiveConnections { get; }
    }
}