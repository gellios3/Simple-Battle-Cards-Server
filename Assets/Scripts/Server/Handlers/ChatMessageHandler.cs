using Server.Interfaces;
using Server.Signals;
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
        
        [Inject] public SendMessageSignal SendMessageSignal { get; set; }

        /// <summary>
        /// On
        /// </summary>
        /// <param name="message"></param>
        public void Handle(NetworkMessage message)
        {
            var echoMsg = message.ReadMessage<StringMessage>().value;
            SendMessageSignal.Dispatch(echoMsg);

        }
    }
}