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
        /// Get server data handler
        /// </summary>
        [Inject]
        public GetServerDataHandler GetServerDataHandler { get; set; }

        [Inject] public ServerConnectorService ServerConnectorService { get; set; }

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
                ServerConnectorService.Send(MsgStruct.EchoMsgId, new StatusMessage());
            }
            else
            {
                Debug.Log("Conection error!!");
            }
        }
    }
}