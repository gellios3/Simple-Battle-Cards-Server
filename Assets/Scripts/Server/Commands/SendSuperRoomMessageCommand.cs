using Client.Models;
using Models.SuperGame;
using strange.extensions.command.impl;

namespace Server.Commands
{
    public class SendSuperRoomMessageCommand : Command
    {
        /// <summary>
        /// Game serverService connector
        /// </summary>
        [Inject]
        public GameServerService GameServerService { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [Inject]
        public SuperGameMessage Message { get; set; }

        /// <summary>
        /// Execute
        /// </summary>
        public override void Execute()
        {
            GameServerService.Send(GameServerService.ActiveConnections, MsgStruct.SuperRoomResponse, Message);
        }
    }
}