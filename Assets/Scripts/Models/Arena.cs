using System.Collections.Generic;

namespace Models
{
    public class Arena
    {
        /// <summary>
        /// Your player
        /// </summary>
        public Player YourPlayer { get; set; }

        /// <summary>
        /// Enemy player
        /// </summary>
        public Player EnemyPlayer { get; set; }

        /// <summary>
        /// Battle 
        /// </summary>
        public Battle CuttentBattle { get; set; }

        /// <summary>
        /// Firt turm
        /// </summary>
        public BattleState FirstTurn { get; set; }

        /// <summary>
        /// Battle history
        /// </summary>
        public List<Battle> History { get; set; }
    }
}