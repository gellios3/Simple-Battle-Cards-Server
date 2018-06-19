using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

namespace Client
{
    public interface IServerConnector
    {
        void Connect();
        void DisconectFromServer();

        void Send(short msgId, MessageBase msg);
        void RegisterHandlers(IEnumerable<IServerMessageHandler> handlers);
    }
}