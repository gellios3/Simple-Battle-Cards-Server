using System.Linq;
using System.Xml.Linq;
using Models;
using Models.RegularGame;
using Models.SuperGame;
using strange.extensions.command.impl;
using Server.Signals;
using UniRx;

namespace Server.Commands
{
    public class FetchRoomListCommand : Command
    {
        /// <summary>
        /// Rooms fetched signal
        /// </summary>
        [Inject]
        public StartListeningServerSignal ListeningServerSignal { get; set; }
        
        /// <summary>
        /// Room list data
        /// </summary>
        [Inject] public RoomsListData RoomsListData { get; set; }

        /// <summary>
        /// Execute event load rooms list 
        /// </summary>
        public override void Execute()
        {
            Observable.Start(() =>
            {
                // load xml file
                var xDocument = XDocument.Load("./Assets/Resources/data.xml");
                // init room list data
                var roomsListData = new RoomsListData();

                // Init regular games
                var xRegularGames = xDocument.Descendants("room").ToArray();
                foreach (var xGame in xRegularGames)
                {
                    roomsListData.RegularGames.Add(new BaseRegularGame
                    {
                        Id = (string) xGame.Attribute("id"),
                        CurrentPlayers = (int) xGame.Attribute("players"),
                        MaxPlayers = (int) xGame.Attribute("maxPlayers"),
                        Name = xGame.Value,
                        Price = (int) xGame.Attribute("price")
                    });
                }

                roomsListData.RegularGames.Sort((a, b) => string.CompareOrdinal(a.Name, b.Name));

                // Init super games
                var xSuperGames = xDocument.Descendants("supergame").ToArray();
                foreach (var xGame in xSuperGames)
                {
                    roomsListData.SuperGames.Add(new BaseSuperGame
                    {
                        Id = (string) xGame.Attribute("id"),
                        Price = (int) xGame.Attribute("price"),
                        MaxPlayers = (int) xGame.Attribute("max"),
                        CurrentPlayers = (int) xGame.Attribute("current")
                    });
                }

                return roomsListData;
            }).ObserveOnMainThread().Subscribe(res =>
            {
                if (res != null)
                {
                    RoomsListData.RegularGames = res.RegularGames;
                    RoomsListData.SuperGames = res.SuperGames;
                }

                // On listening server signal
                ListeningServerSignal.Dispatch();
            });
        }
    }
}