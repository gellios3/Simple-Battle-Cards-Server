//using Client.Models;
//using Client.Signals;
//using Models;
//using Models.SuperGame;
//using UnityEngine;
//using UnityEngine.Networking;
//
//namespace Client.Handlers
//{
//    public class GetServerSuperRoomHandler : IServerMessageHandler
//    {
//        /// <summary>
//        /// Message type
//        /// </summary>
//        public short MessageType => MsgStruct.SuperRoomResponse;
//
//        /// <summary>
//        /// Add super game view signal
//        /// </summary>
//        [Inject]
//        public AddSuperGameViewSignal AddSuperGameViewSignal { get; set; }
//
//        /// <summary>
//        /// Handle server message
//        /// </summary>
//        /// <param name="msg"></param>
//        public void Handle(NetworkMessage msg)
//        {
//            var superGameMessageMsg = msg.ReadMessage<SuperGameMessage>();
//            if (superGameMessageMsg != null)
//            {
//                AddSuperGameViewSignal.Dispatch(new BaseSuperGame
//                {
//                    CurrentPlayers = superGameMessageMsg.CurrentPlayers,
//                    Id = superGameMessageMsg.Id,
//                    MaxPlayers = superGameMessageMsg.MaxPlayers,
//                    Price = superGameMessageMsg.Price
//                });
//            }
//        }
//    }
//}