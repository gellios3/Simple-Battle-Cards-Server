using System.Linq;
using System.Xml.Linq;
using Models;
using strange.extensions.command.impl;
using Signals;
using UniRx;

namespace Client.Commands
{
    public class FetchRoomListCommand : Command
    {
        /// <summary>
        /// Room list data
        /// </summary>
        [Inject]
        public RoomListData RoomListData { get; set; }

        /// <summary>
        /// Rooms fetched signal
        /// </summary>
        [Inject] public RoomsFetchedSignal RoomsFetchedSignal { get; set; }

        /// <summary>
        /// Execute event load rooms list 
        /// </summary>
        public override void Execute()
        {
            Observable.Start(() =>
            {
                // load xml file
                var xDocument = XDocument.Load("./Assets/Resources/data.xml");

                // Init regular games
                var xRegularGames = xDocument.Descendants("room").ToArray();
                foreach (var game in xRegularGames)
                {
                    RoomListData.RegularGames.Add(new RegularGame(game));
                }

                RoomListData.RegularGames.Sort((a, b) => string.CompareOrdinal(a.Name, b.Name));

                // Init super games
                var xSuperGames = xDocument.Descendants("supergame").ToArray();
                foreach (var game in xSuperGames)
                {
                    RoomListData.SurerGames.Add(new SuperGame(game));
                }
            }).ObserveOnMainThread().Subscribe(r => { RoomsFetchedSignal.Dispatch(); });
        }
    }
}