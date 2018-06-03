using Models;
using strange.extensions.mediation.impl;
using Signals;
using UnityEngine;

namespace View
{
    public class RoomGridView : EventView
    {
        /// <summary>
        /// On rooms fetched
        /// </summary>
        /// <param name="roomListData"></param>
        public void OnRoomsFetched(RoomListData roomListData)
        {
            // init super rooms
            foreach (var game in roomListData.SurerGames)
            {
                var superRoom = (GameObject) Instantiate(
                    Resources.Load("Prefabs/SuperRoom", typeof(GameObject)), new Vector2(), Quaternion.identity,
                    transform
                );
                superRoom.GetComponent<SuperRoomManager>().Game = game;
            }

            // init regular rooms
            foreach (var game in roomListData.RegularGames)
            {
                var regularRoom = (GameObject) Instantiate(
                    Resources.Load("Prefabs/RegularRoom", typeof(GameObject)), new Vector2(), Quaternion.identity,
                    transform
                );
                regularRoom.GetComponent<RegularRoomView>().Game = game;
            }
        }
    }

    public class RoomGridViewMediator : TargetMediator<RoomGridView>
    {
        [Inject] public RoomsFetchedSignal RoomsFetchedSignal { get; set; }

        [Inject] public RoomListData RoomListData { get; set; }

        public override void OnRegister()
        {
            RoomsFetchedSignal.AddListener(OnRoomsFetched);
        }

        public void OnRoomsFetched()
        {
            View.OnRoomsFetched(RoomListData);
        }
    }
}