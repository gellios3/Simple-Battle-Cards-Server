using Models.ScriptableObjects;
using UnityEngine;

namespace Models
{
    public class BattleTrate
    {
        /// <summary>
        /// Defence
        /// </summary>
        public int Defence { get; private set; }

        /// <summary>
        /// Attack
        /// </summary>
        public int Health { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="trate"></param>
        public BattleTrate(Trate trate = null)
        {
            if (trate != null)
            {
                Defence = trate.Defence;
                Health = trate.Health;
            }
            else
            {
                Defence = Random.Range(0, 5);
                Health = Random.Range(0, 5);
            }
        }
    }
}