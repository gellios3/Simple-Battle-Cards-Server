﻿using System.Collections.Generic;
using UnityEngine.Networking;

namespace Client.Interfaces
{
    public interface IServerConnector
    {
        void Connect();
        void DisconectFromServer();

        void Send(short msgId, MessageBase msg);
        void RegisterHandlers(IEnumerable<IServerMessageHandler> handlers);
    }
}