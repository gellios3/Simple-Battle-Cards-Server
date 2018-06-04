using strange.extensions.mediation.impl;
using Signals.Arena;
using UnityEngine;

namespace View.Arena
{
    public class GameArenaView : EventView
    {
        public void OnArenaInitialized()
        {
            Debug.Log("OnInitArena");
        }
    }

    /// <summary>
    /// Room grid view mediator
    /// </summary>
    public class GameArenaMediator : TargetMediator<GameArenaView>
    {
        [Inject] public ArenaInitializedSignal ArenaInitializedSignal { get; set; }

        public override void OnRegister()
        {
            ArenaInitializedSignal.AddListener(ArenaInitialized);
        }

        private void ArenaInitialized()
        {
            View.OnArenaInitialized();
        }
    }
}