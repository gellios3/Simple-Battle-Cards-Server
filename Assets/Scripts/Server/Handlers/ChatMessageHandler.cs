using Server.Interfaces;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

namespace Server.Handlers
{
    public class ChatMessageHandler : IServerHandler
    {
        /// <summary>
        /// Message Type
        /// </summary>
        public short MessageType => MsgId.echoMsgId;

        /// <summary>
        /// Game serverService connector
        /// </summary>
        public GameServerService GameServerService { private get; set; }

        /// <summary>
        /// On
        /// </summary>
        /// <param name="message"></param>
        public void Handle(NetworkMessage message)
        {
            var echoMsg = message.ReadMessage<StringMessage>().value;
            echoMsg += " from server";

            var responseMsg = new StringMessage(echoMsg);
            GameServerService.Send(GameServerService.ActiveConnections, MsgId.echoServerResponse,
                responseMsg);
        }
    }
}