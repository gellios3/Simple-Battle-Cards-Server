using Models;
using strange.extensions.command.impl;
using Server.Services;

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
            GameServerService.Send(GameServerService.ActiveConnections, MsgStruct.GetRegisteredPlayers, new LobbyPlayersMessage
            {
                Players = NetworkLobbyService.Players.ToArray()
            });
        }
    }
}