using strange.extensions.mediation.impl;
using View;

namespace Client.View
{
    public class RoomGridView : EventView
    {
        /// <summary>
        /// On rooms fetched
        /// </summary>
        /// <param name="gamesSyncList"></param>
//        public void OnRoomsFetched(GamesSyncList gamesSyncList)
//        {
//            // init super rooms
//            foreach (var game in roomListData.SurerGames)
//            {
//                var superRoom = (GameObject) Instantiate(
//                    Resources.Load("Prefabs/SuperRoom", typeof(GameObject)), new Vector2(), Quaternion.identity,
//                    transform
//                );
//                superRoom.GetComponent<SuperRoomView>().Game = game;
//            }
//
//            // init regular rooms
//            foreach (var game in roomListData.RegularGames)
//            {
//                var regularRoom = (GameObject) Instantiate(
//                    Resources.Load("Prefabs/RegularRoom", typeof(GameObject)), new Vector2(), Quaternion.identity,
//                    transform
//                );
//                regularRoom.GetComponent<RegularRoomView>().Game = game;
//            }
//        }
    }

    /// <summary>
    /// Room grid view mediator
    /// </summary>
    public class RoomGridViewMediator : TargetMediator<RoomGridView>
    {
//        [Inject] public RoomsFetchedSignal RoomsFetchedSignal { get; set; }

//        [Inject] public RoomListData RoomListData { get; set; }

        public override void OnRegister()
        {
//            RoomsFetchedSignal.AddListener(OnRoomsFetched);
        }

        private void OnRoomsFetched()
        {
//            View.OnRoomsFetched(RoomListData);
        }
    }
}