using strange.extensions.command.impl;
using Server.Signals;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

namespace Server.Commands
{
    public class StartListeningCommand : Command
    {
        /// <summary>
        /// Disconnect server signal
        /// </summary>
        [Inject]
        public DisconnectSignal DisconnectSignal { get; set; }

        /// <summary>
        /// On sever error 
        /// </summary>
        [Inject]
        public ServerErrorSignal ServerErrorSignal { get; set; }

        /// <summary>
        /// Server connected signal
        /// </summary>
        [Inject]
        public ServerConnectedSignal ServerConnectedSignal { get; set; }

        /// <summary>
        /// On Execute event 
        /// </summary>
        public override void Execute()
        {
            // Regiter basic networck events
            NetworkServer.RegisterHandler(MsgType.Connect, msg => { ServerConnectedSignal.Dispatch(true); });
            NetworkServer.RegisterHandler(MsgType.Disconnect, msg => { DisconnectSignal.Dispatch(true); });
            NetworkServer.RegisterHandler(MsgType.Error, msg =>
            {
                var error = msg.ReadMessage<ErrorMessage>();
                ServerErrorSignal.Dispatch(error.ToString());
            });
            //                    // init regular game sync list
//                    foreach (var game in res.RegularGames)
//                    {
//                        GamesSyncList.RegularGames.Add(new StructRegularGame
//                        {
//                            Id = game.Id,
//                            MaxPlayers = game.MaxPlayers,
//                            Name = game.Name,
//                            CurrentPlayers = game.CurrentPlayers,
//                            Price = game.Price
//                        });
//                    }
//
//                    // init super game sync list
//                    foreach (var game in res.SuperGames)
//                    {
//                        GamesSyncList.SurerGames.Add(new StructSuperGame
//                        {
//                            Id = game.Id,
//                            MaxPlayers = game.MaxPlayers,
//                            CurrentPlayers = game.CurrentPlayers,
//                            Price = game.Price
//                        });
//                    }
        }
    }
}