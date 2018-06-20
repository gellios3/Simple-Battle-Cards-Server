using Client.Handlers;
using Client.Models;
using Models;
using strange.extensions.command.impl;
using UnityEngine;
using UnityEngine.Networking.NetworkSystem;

namespace Client.Commands
{
    public class ServerConectedCommand : Command
    {
        /// <summary>
        /// Server connector service
        /// </summary>
        [Inject]
        public ServerConnectorService ServerConnectorService { get; set; }

        /// <summary>
        /// Is connected
        /// </summary>
        [Inject]
        public bool IsConnected { get; set; }

        /// <summary>
        /// Execute connectipon signal
        /// </summary>
        public override void Execute()
        {
            if (IsConnected)
            {
                ServerConnectorService.Send(MsgStruct.EchoMsgId, new ClientMessage
                {
                    RoomType = RoomType.Super,
                    Status = StatusMsg.Adding
                });
                
                ServerConnectorService.Send(MsgStruct.EchoMsgId, new ClientMessage
                {
                    RoomType = RoomType.Regular,
                    Status = StatusMsg.Adding
                });
            }
            else
            {
                Debug.Log("Conection error!!");
            }
        }
    }
}