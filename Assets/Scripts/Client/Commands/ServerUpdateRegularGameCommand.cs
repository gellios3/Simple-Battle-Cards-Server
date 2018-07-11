using Client.Models;
using Models;
using Models.RegularGame;
using strange.extensions.command.impl;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

namespace Client.Commands
{
    public class ServerUpdateRegularGameCommand : Command
    {
        /// <summary>
        /// REgular game
        /// </summary>
        [Inject]
        public BaseRegularGame RegularGame { get; set; }

        /// <summary>
        /// Server connector service
        /// </summary>
        [Inject]
        public ServerConnectorService ServerConnectorService { get; set; }

        /// <summary>
        /// Execute current signal
        /// </summary>
        public override void Execute()
        {
            Debug.Log("ServerUpdateRegularGameCommand");
            RegularGame.CurrentPlayers++;
//            ServerConnectorService.Send(MsgStruct.EchoMsgId, new ClientMessage
//            {
//                Id = RegularGame.Id,
//                CurrentPlayers = RegularGame.CurrentPlayers,
//                RoomType = RoomType.Regular,
//                Status = StatusMsg.Editing
//            });
        }
    }
}