using Client.Models;
using Models;
using Models.RegularGame;
using strange.extensions.command.impl;

namespace Server.Commands
{
    public class SendRegularRoomMessageCommand : Command
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
        public RegularGameMessage Message { get; set; }

        /// <summary>
        /// Execute
        /// </summary>
        public override void Execute()
        {            
            GameServerService.Send(GameServerService.ActiveConnections, MsgStruct.RegularRoomResponse, Message);
        }
    }
}