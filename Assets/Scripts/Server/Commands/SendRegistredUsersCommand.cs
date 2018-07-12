using Models;
using Models.Messages;
using strange.extensions.command.impl;
using Server.Services;
using UnityEngine;

namespace Server.Commands
{
    public class SendRegistredUsersCommand : Command
    {
        /// <summary>
        /// Game serverService connector
        /// </summary>
        [Inject]
        public GameServerService GameServerService { get; set; }

        [Inject] public NetworkLobbyService NetworkLobbyService { get; set; }

        public override void Execute()
        {
            Debug.Log("SendRegistredUsersCommand");
            GameServerService.Send(GameServerService.ActiveConnections, MsgStruct.GetRegisteredPlayers,
                new LobbyPlayersMessage
                {
                    Players = NetworkLobbyService.Players.ToArray()
                });
        }
    }
}