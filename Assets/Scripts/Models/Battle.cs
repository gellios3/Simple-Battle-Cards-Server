using System.Collections.Generic;
using Models.ScriptableObjects;

namespace Models
{
    public class Battle
    {
        public BattleState State { get; private set; }

        public Battle(BattleState state)
        {
            State = state;
        }
        
        public void HitCarts(Card card)
        {
            
        }
    }

    public enum BattleState
    {
        YourTurn,
        EnemyTurn
    }
}