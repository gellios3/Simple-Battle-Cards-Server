using System.Collections.Generic;
using Models.ScriptableObjects;
using UnityEngine;

namespace Models
{
    public class BattleArena
    {
        /// <summary>
        /// Active state
        /// </summary>
        public BattleState ActiveState { get; set; }

        /// <summary>
        /// Battle history
        /// </summary>
        public List<HistoryItem> History { get; private set; }

        /// <summary>
        /// Batle turn
        /// </summary>
        public BattleTurn ActiveBattleTurn { get; private set; }

        /// <summary>
        /// Init battle turn
        /// </summary>
        public void InitActiveTurn(Player player)
        {
            player.FillBattleHand();
            player.Status = PlayerStatus.Active;
        }

        /// <summary>
        /// Init activa battle turn
        /// </summary>
        /// <param name="player"></param>
        public void InitActiveBattleTurn(Player player)
        {
            ActiveBattleTurn = new BattleTurn(player);
        }

        /// <summary>
        /// End turn
        /// </summary>
        public void EndTurn(Player player)
        {
            // Switch active state
            ActiveState = ActiveState == BattleState.YourTurn ? BattleState.EnemyTurn : BattleState.YourTurn;

            // Set active all not dead areana cards 
            foreach (var card in player.ArenaCards)
            {
                if (card.Status != CardStatus.Dead)
                {
                    card.Status = CardStatus.Active;
                    Debug.Log("Activate " + card.SourceCard.name + " card");
                }
            }

            Debug.Log("End " + player.Name + " turn");
        }
    }

    public enum BattleState
    {
        YourTurn,
        EnemyTurn
    }
}