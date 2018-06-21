using Client.Models;
using Client.Signals;
using Models;
using Models.RegularGame;
using UnityEngine;
using UnityEngine.Networking;

namespace Client.Handlers
{
    public class GetServerRegularRoomHandler : IServerMessageHandler
    {
        /// <summary>
        /// Message type
        /// </summary>
        public short MessageType => MsgStruct.RegularRoomResponse;

        /// <summary>
        /// Room list data
        /// </summary>
        [Inject]
        public UpdateRegularGameDataSignal UpdateRegularGameDataSignal { get; set; }

        public void Handle(NetworkMessage msg)
        {
            var regularMsg = msg.ReadMessage<RegularGameMessage>();
            if (regularMsg != null)
            {
                UpdateRegularGameDataSignal.Dispatch(new BaseRegularGame
                {
                    CurrentPlayers = regularMsg.CurrentPlayers,
                    Id = regularMsg.Id,
                    MaxPlayers = regularMsg.MaxPlayers,
                    Name = regularMsg.Name,
                    Price = regularMsg.Price
                });
            }
        }
    }
}