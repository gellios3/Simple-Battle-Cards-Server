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
        /// <summary>
        /// Arena
        /// </summary>
        [Inject]
        public Arena Arena { get; set; }

        /// <summary>
        /// Your CPU Behavior
        /// </summary>
        [Inject]
        public PlayerCpuBehavior YourPlayerCpu { get; set; }

        /// <summary>
        /// Enemy CPU Behavior
        /// </summary>
        [Inject]
        public PlayerCpuBehavior EnemyPlayerCpu { get; set; }

        /// <summary>
        /// Battle
        /// </summary>
        [Inject]
        public BattleArena BattleArena { get; set; }

        [Inject] public ArenaInitializedSignal ArenaInitializedSignal { get; set; }

        /// <summary>
        /// Execute event load rooms list 
        /// </summary>
        public override void Execute()
        {
            // Load regular deck
            var deck = Resources.Load<Deck>("Objects/Decks/Regular");
            // init arena
            Arena.Init(deck, deck);
            Arena.YourPlayer.Name = "Player";
            Arena.EnemyPlayer.Name = "CPU 1";
            // Init batle in your turn
            BattleArena.ActiveState = BattleState.YourTurn;
            // init current player
            var player = BattleArena.ActiveState == BattleState.YourTurn ? Arena.YourPlayer : Arena.EnemyPlayer;

            // Init player Cpu Behavior
            YourPlayerCpu.Init(player);
            YourPlayerCpu.InitTurn();
            YourPlayerCpu.MakeBattleTurn();

            Observable.Start(() => { Debug.Log("Logic"); }).ObserveOnMainThread()
                .Subscribe(res => { ArenaInitializedSignal.Dispatch(); });
        }
    }
}