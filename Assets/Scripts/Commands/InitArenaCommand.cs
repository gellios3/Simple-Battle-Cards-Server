using Models;
using Models.ScriptableObjects;
using strange.extensions.command.impl;
using Signals.Arena;
using UniRx;
using UnityEngine;

namespace Commands
{
    public class InitArenaCommand : Command
    {
        [Inject] public Arena Arena { get; set; }

        [Inject] public ArenaInitializedSignal ArenaInitializedSignal { get; set; }

        /// <summary>
        /// Execute event load rooms list 
        /// </summary>
        public override void Execute()
        {
            // Load regular deck
            var deck = Resources.Load<Deck>("Objects/Decks/Regular");
            Arena.FirstTurn = BattleState.YourTurn;
            Arena.YourPlayer = new Player(deck);
//            Arena.EnemyPlayer = new Player(deck);
            Observable.Start(() => { Debug.Log("Logic"); }).ObserveOnMainThread()
                .Subscribe(res => { ArenaInitializedSignal.Dispatch(); });
        }
    }
}