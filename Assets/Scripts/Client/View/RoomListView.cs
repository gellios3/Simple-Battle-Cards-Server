using Client.Signals;
using Models.RegularGame;
using Models.SuperGame;
using strange.extensions.mediation.impl;
using UnityEngine;
using View;

namespace Client.View
{
    public class RoomListView : EventView
    {
        /// <summary>
        /// Add regular game view on scene
        /// </summary>
        /// <param name="game"></param>
        public void AddRegularGameView(BaseRegularGame game)
        {
            var regularRoom = (GameObject) Instantiate(
                Resources.Load("Prefabs/RegularRoom", typeof(GameObject)), new Vector2(), Quaternion.identity,
                transform
            );
            regularRoom.GetComponent<RegularRoomView>().Game = game;
        }

        /// <summary>
        /// Add super game view on scene
        /// </summary>
        /// <param name="game"></param>
        public void AddSuperGameView(BaseSuperGame game)
        {
            var superRoom = (GameObject) Instantiate(
                Resources.Load("Prefabs/SuperRoom", typeof(GameObject)), new Vector2(), Quaternion.identity,
                transform
            );
            superRoom.GetComponent<SuperRoomView>().Game = game;
        }

        /// <summary>
        /// Update regular game view
        /// </summary>
        /// <param name="game"></param>
        public void UpdateRegularGameView(BaseRegularGame game)
        {
            Debug.Log("UpdateRegularGameView" + game.Id);
        }
    }

    /// <summary>
    /// Room grid view mediator
    /// </summary>
    public class RoomGridViewMediator : TargetMediator<RoomListView>
    {
        /// <summary>
        /// Add regular game view signal
        /// </summary>
        [Inject]
        public AddRegularGameViewSignal AddRegularGameViewSignal { get; set; }

        /// <summary>
        /// Add super game view signal
        /// </summary>
        [Inject]
        public AddSuperGameViewSignal AddSuperGameViewSignal { get; set; }

        /// <summary>
        /// Update regular game view signal
        /// </summary>
        [Inject]
        public UpdateRegularGameViewSignal UpdateRegularGameViewSignal { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            UpdateRegularGameViewSignal.AddListener(regularGame => { View.UpdateRegularGameView(regularGame); });
            AddRegularGameViewSignal.AddListener(regularGame => { View.AddRegularGameView(regularGame); });
            AddSuperGameViewSignal.AddListener(superGame => { View.AddSuperGameView(superGame); });
        }
    }
}