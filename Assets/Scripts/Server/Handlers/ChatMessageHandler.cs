using Client.Models;
using Models;
using Server.Interfaces;
using Server.Signals;
using UnityEngine.Networking;

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
            var echoMsg = message.ReadMessage<StatusMessage>();
            SendMessageSignal.Dispatch(echoMsg);
        }
    }
}