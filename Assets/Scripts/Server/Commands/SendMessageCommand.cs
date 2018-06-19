using System.Collections.Generic;
using Client.Models;
using Models;
using strange.extensions.command.impl;

namespace Server.Commands
{
    public class SendMessageCommand : Command
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
        public StatusMessage Message { get; set; }

        /// <summary>
        /// Execute
        /// </summary>
        public override void Execute()
        {
            if (Message.Status == StatusMsg.Sending)
            {
                var responseMsg = new RoomListMessage
                {
                    RegularGames = new List<RegularGameStruct>()
                };
                responseMsg.RegularGames.Add(new RegularGameStruct
                {
                    Name = "test"
                });
                GameServerService.Send(GameServerService.ActiveConnections, MsgStruct.EchoServerResponse, responseMsg);
            }
        }
    }
}