using Models.RegularGame;
using strange.extensions.command.impl;
using Server.Models;
using UnityEngine;

namespace Server.Commands
{
    public class StartServerCommand : Command
    {
        /// <summary>
        /// Networking game server
        /// </summary>
        [Inject]
        public GameServerService GameServerService { get; set; }

        [Inject] public int serverPort { get; set; }

        /// <summary>
        /// Execute
        /// </summary>
        public override void Execute()
        {
            GameServerService.StartServer(serverPort);
        }
    }
}