using Models;
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
        public short MessageType => MsgStruct.RegisterPlayer;

        [Inject] public NetworkLobbyService NetworkLobbyService { get; set; }
        
        [Inject] public SendRegistredUsersSignal SendRegistredUsersSignal { get; set; }

        public void Handle(NetworkMessage message)
        {
            var registerPlayerMessage = message.ReadMessage<PlayerMessage>();
            if (registerPlayerMessage != null)
            {
                NetworkLobbyService.Players.AddUnique(new PlayerStruct
                {
                    Id = registerPlayerMessage.Id,
                    Name = registerPlayerMessage.Name,
                    IsConnected = registerPlayerMessage.IsConnected
                });
                SendRegistredUsersSignal.Dispatch();
            }
        }
    }
}