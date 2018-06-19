using Client.Models;
using Models;
using Models.RegularGame;
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
                var responseMsg = new RegularGameMessage
                {
                    Name = "test",
                    CurrentPlayers = 0,
                    MaxPlayers = 10,
                    Price = 100
                };
                GameServerService.Send(GameServerService.ActiveConnections, MsgStruct.EchoServerResponse, responseMsg);
            }
        }
    }
}