﻿
using Models.ScriptableObjects;
using UnityEngine;

namespace Models
{
    public class BattleCard
    {
        /// <summary>
        /// Defence
        /// </summary>
        public int Defence { get; private set; }

        /// <summary>
        /// Attack
        /// </summary>
        public int Attack { get; private set; }

        /// <summary>
        /// Health
        /// </summary>
        public int Health { get; private set; }

        /// <summary>
        /// Source card
        /// </summary>
        public Card SourceCard { get; private set; }

        /// <summary>
        /// Is card dead
        /// </summary>
        public bool IsDead { get; private set; }
        
        /// <summary>
        /// Is sleep
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// Card take damage
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(int damage)
        {
            if (Defence > 0)
            {
                // Hit defence
                Defence -= damage;
                // Is defence less 0 hit health
                if (Defence < 0)
                {
                    damage += Defence;
                    Health -= Defence;
                }
                else
                {
                    damage = 0;
                }
            }

            if (Health > 0)
            {
                Health -= damage;
            }

            if (Health <= 0)
            {
                IsDead = true;
            }
        }

        /// <summary>
        /// Add trate to battle card
        /// </summary>
        /// <param name="trate"></param>
        public void AddTrate(BattleTrate trate)
        {
            Defence += trate.Defence;
            Health += trate.Health;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="card"></param>
        public BattleCard(Card card = null)
        {
            if (card != null)
            {
                SourceCard = card;
                Defence = card.Defence;
                Attack = card.Attack;
                Health = card.Health;
                
                if (card.Trates.Count <= 0) return;

                foreach (var trate in card.Trates)
                {
                    Defence += trate.Defence;
                    Health += trate.Health;
                }
            }
            else
            {
                // Create random card
                Defence = Random.Range(1, 6);
                Attack = Random.Range(1, 6);
                Health = Random.Range(1, 6);
            }

            IsDead = false;
            IsActive = false;
        }
    }
}