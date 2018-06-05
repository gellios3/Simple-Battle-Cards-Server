using System.Collections;
using Models.ScriptableObjects;

namespace Models
{
    public class BattleTurn
    {
        public Player ActivePlayer { get; private set; }

        /// <summary>
        /// Battle turn
        /// </summary>
        /// <param name="player"></param>
        public BattleTurn(Player player)
        {
            ActivePlayer = player;
        }

        public void AddActiveCardFromHand(BattleCard card)
        {
            ActivePlayer.ArenaCards.Add(card);
        }

        public void AddTrateToActiveCard(BattleCard card, BattleTrate trate)
        {
            card.AddTrate(trate);
        }
        
        
    }
}