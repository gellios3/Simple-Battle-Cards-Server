using Client.Models;
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
        public short MessageType => MsgStruct.EchoMsgId;
        
        /// <summary>
        /// Send message signal
        /// </summary>
        [Inject] public SendMessageSignal SendMessageSignal { get; set; }

        /// <summary>
        /// On Message Handle 
        /// </summary>
        /// <param name="message"></param>
        public void Handle(NetworkMessage message)
        {
            var echoMsg = message.ReadMessage<StringMessage>().value;
            SendMessageSignal.Dispatch(echoMsg);

        }
    }
}