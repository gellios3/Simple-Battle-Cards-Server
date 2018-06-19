using Client.Models;
using strange.extensions.command.impl;
using UnityEngine.Networking.NetworkSystem;

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
        [Inject] public string Message { get; set; }

        /// <summary>
        /// Execute
        /// </summary>
        public override void Execute()
        {
            Message += " from server";
            var responseMsg = new StringMessage(Message);
            GameServerService.Send(GameServerService.ActiveConnections, MsgStruct.EchoServerResponse, responseMsg);
        }
    }
}