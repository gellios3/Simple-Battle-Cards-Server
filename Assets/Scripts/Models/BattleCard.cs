using Models.ScriptableObjects;

namespace Models
{
    public class BattleCard
    {
        /// <summary>
        /// Defence
        /// </summary>
        public int Defence { get; set; }

        /// <summary>
        /// Attack
        /// </summary>
        public int Attack { get; set; }

        /// <summary>
        /// Health
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Source card
        /// </summary>
        public Card SourceCard { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="card"></param>
        public BattleCard(Card card)
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
    }
}