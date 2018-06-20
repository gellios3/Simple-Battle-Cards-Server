using Models.RegularGame;
using strange.extensions.command.impl;
using Server.Models;
using UnityEngine;

namespace Server.Commands
{
    public class ServerConnectedCommand : Command
    {
        [Inject] public GamesSyncList GamesSyncList { get; set; }

        public override void Execute()
        {
            Debug.Log("GamesSyncList");
//            GamesSyncList.RegularGames.Add(new StructRegularGame
//            {
//                Id = "100",
//                Name = "test",
//                CurrentPlayers = 0,
//                MaxPlayers = 10,
//                Price = 100
//            });
        }
    }
}