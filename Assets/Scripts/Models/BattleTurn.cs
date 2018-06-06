using System.Collections;
using Models.ScriptableObjects;
using UnityEngine;

namespace Models
{
    public class BattleTurn
    {
        /// <summary>
        /// Active player
        /// </summary>
        public Player ActivePlayer { get; private set; }

        /// <summary>
        /// Battle turn
        /// </summary>
        /// <param name="player"></param>
        public BattleTurn(Player player)
        {
            ActivePlayer = player;
        }

        /// <summary>
        /// Add active card from hand
        /// </summary>
        /// <param name="card"></param>
        public void AddActiveCardFromHand(BattleCard card)
        {
            ActivePlayer.ArenaCards.Add(card);
            Debug.Log("Add card " + card.SourceCard.name);
        }

        /// <summary>
        /// Add trate to actice card
        /// </summary>
        /// <param name="card"></param>
        /// <param name="trate"></param>
        public void AddTrateToActiveCard(BattleCard card, BattleTrate trate)
        {
            card.AddTrate(trate);
            Debug.Log("Add trate " + trate.SourceTrate.name + " to card " + card.SourceCard.name);
        }

        /// <summary>
        /// Hit Enemy Card
        /// </summary>
        /// <param name="yourCard"></param>
        /// <param name="enemyCard"></param>
        public void HitEnemyCard(BattleCard yourCard, BattleCard enemyCard)
        {
            Debug.Log("Card " + yourCard.SourceCard.name + " hit ememy Card " + enemyCard.SourceCard.name +
                      " take damage" + yourCard.Attack);
            enemyCard.TakeDamage(yourCard.Attack);
            Debug.Log("Enemy card has " + enemyCard.Health + " Health and" + enemyCard.Defence + " Defence");
        }
        
        
    }
}