using System.Collections.Generic;
using Models.ScriptableObjects;

namespace Models
{
    public class PlayerCpuBehavior
    {
        /// <summary>
        /// Battle
        /// </summary>
        [Inject]
        public BattleArena BattleArena { get; set; }

        /// <summary>
        /// Arena
        /// </summary>
        [Inject]
        public Arena Arena { get; set; }

        /// <summary>
        /// Active player
        /// </summary>
        public Player ActivePlayer { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public void Init(Player player)
        {
            ActivePlayer = player;
        }

        /// <summary>
        /// Init turn
        /// </summary>
        public void InitTurn()
        {
            // init active turn
            BattleArena.InitActiveTurn(ActivePlayer);
            // init battle turn 
            BattleArena.InitActiveBattleTurn(ActivePlayer);
        }

        /// <summary>
        /// Make Battle turn
        /// </summary>
        public void MakeBattleTurn()
        {
            // add all cards to battle arena
            foreach (var item in ActivePlayer.BattleHand)
            {
                var card = item as BattleCard;
                if (card != null)
                {
                    BattleArena.ActiveBattleTurn.AddActiveCardFromHand(card);
                }
            }

            // add all trares to card
            if (ActivePlayer.ArenaCards.Count > 0)
            {
                foreach (var item in ActivePlayer.BattleHand)
                {
                    var trate = item as BattleTrate;
                    if (trate != null)
                    {
                        BattleArena.ActiveBattleTurn.AddTrateToActiveCard(ActivePlayer.ArenaCards[0], trate);
                    }
                }
            }

            var enemyCards = GetEnemyActiveCards();
            var activeCards = ActivePlayer.ArenaCards.FindAll(card => card.IsActive);
            if (enemyCards.Count > 0 && activeCards.Count > 0)
            {
            }
        }

        private List<BattleCard> GetEnemyActiveCards()
        {
            return BattleArena.ActiveState == BattleState.YourTurn
                ? Arena.EnemyPlayer.ArenaCards
                : Arena.YourPlayer.ArenaCards;
        }
    }
}