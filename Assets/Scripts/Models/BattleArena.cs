using System.Collections.Generic;
using Models.ScriptableObjects;

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
        public void EndTurn()
        {
            ActiveState = ActiveState == BattleState.YourTurn ? BattleState.EnemyTurn : BattleState.YourTurn;
        }
    }

    public enum BattleState
    {
        YourTurn,
        EnemyTurn
    }
}