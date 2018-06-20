using Client.Models;
using Models;
using Models.RegularGame;
using strange.extensions.command.impl;
using Server.Models;
using UnityEngine;

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

        [Inject] public GamesSyncList GamesSyncList { get; set; }

        /// <summary>
        /// Execute
        /// </summary>
        public override void Execute()
        {
            if (Message.Status != StatusMsg.Sending) return;
            Debug.Log("GamesSyncList");
            GamesSyncList.RegularGames.Add(new StructRegularGame
            {
                Id = "100",
                Name = "test1",
                CurrentPlayers = 0,
                MaxPlayers = 10,
                Price = 100
            });
//            var responseMsg = new RegularGameMessage
//            {
//                Name = "test",
//                CurrentPlayers = 0,
//                MaxPlayers = 10,
//                Price = 100
//            };
//            
//            GameServerService.Send(GameServerService.ActiveConnections, MsgStruct.EchoServerResponse, responseMsg);
        }
    }
}