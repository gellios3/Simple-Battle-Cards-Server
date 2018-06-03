using System.Linq;
using System.Xml.Linq;
using Models;
using strange.extensions.command.impl;
using Signals;
using UniRx;
using UnityEngine;

namespace Commands
{
    public class FetchRoomListComand : Command
    {
        /// <summary>
        /// Room list data
        /// </summary>
        [Inject]
        public RoomListData RoomListData { get; set; }

        [Inject] public RoomsFetchedSignal RoomsFetchedSignal { get; set; }

        /// <summary>
        /// Execute load rooms list event
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
            }).ObserveOnMainThread().Subscribe(r =>
            {
                Debug.Log("RoomsFetchedSignal.Dispatch");
                RoomsFetchedSignal.Dispatch();
            });
        }
    }
}