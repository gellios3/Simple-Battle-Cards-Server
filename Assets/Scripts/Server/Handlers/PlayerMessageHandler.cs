using Models;
using Models.Messages;
using Server.Interfaces;
using Server.Services;
using Server.Signals;
using UnityEngine;
using UnityEngine.Networking;

namespace Server.Handlers
{
    public class PlayerMessageHandler : IServerHandler
    {
        /// <summary>
        /// Message Type
        /// </summary>
        public short MessageType => MsgStruct.SendPlayer;

        [Inject] public NetworkLobbyService NetworkLobbyService { get; set; }

        [Inject] public SendRegistredUsersSignal SendRegistredUsersSignal { get; set; }

        public void Handle(NetworkMessage message)
        {
            var registerPlayerMessage = message.ReadMessage<PlayerMessage>();
            if (registerPlayerMessage == null) return;

            var item = new PlayerStruct
            {
                Id = registerPlayerMessage.Id,
                Name = registerPlayerMessage.Name,
                IsConected = registerPlayerMessage.IsConnected
            };

            // add or update user
            var index = NetworkLobbyService.Players.IndexOf(item);
            if (index == -1)
            {
                NetworkLobbyService.Players.Add(item);
            }
            else
            {
                NetworkLobbyService.Players[index] = item;
            }

            SendRegistredUsersSignal.Dispatch();
        }
    }
}