using System;
using System.Collections;
using System.Collections.Generic;
using Models.ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Models
{
    public class Player
    {
        /// <summary>
        /// Battle card player hand
        /// </summary>
        private List<BattleCard> _cardHand = new List<BattleCard>();

        public List<BattleCard> CardHand
        {
            get { return _cardHand; }
            set { _cardHand = value; }
        }

        /// <summary>
        /// Battle trate player hand
        /// </summary>
        private List<BattleTrate> _trateHand = new List<BattleTrate>();

        public List<BattleTrate> TrateHand
        {
            get { return _trateHand; }
            set { _trateHand = value; }
        }

        /// <summary>
        /// Active atack cards
        /// </summary>
        private List<BattleCard> _activeCards = new List<BattleCard>();

        public List<BattleCard> ActiveCards
        {
            get { return _activeCards; }
            set { _activeCards = value; }
        }

        /// <summary>
        /// Random battle pul with cartd and trates
        /// </summary>
        private readonly ArrayList _battlePull = new ArrayList();

        public ArrayList BattlePull
        {
            get { return _battlePull; }
        }

        /// <summary>
        /// Random card positions
        /// </summary>
        private readonly List<int> _cardPositions = new List<int>();

        /// <summary>
        /// Random trate positions 
        /// </summary>
        private readonly List<int> _tratePositions = new List<int>();

        /// <summary>
        /// Pull type
        /// </summary>
        private enum PullType
        {
            Card,
            Trate
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="deck"></param>
        public Player(Deck deck)
        {
            // generate random positions
            InitRandomPositions(_cardPositions, deck.Cards.Count);
            InitRandomPositions(_tratePositions, deck.Trates.Count);
            var cardCount = 0;
            var trateCount = 0;
            // fill battle pull
            for (var i = 0; i < deck.Cards.Count + deck.Trates.Count; i++)
            {
                // get random type
                var randomType = Random.Range(0, 2) == 0 ? PullType.Card : PullType.Trate;
                switch (randomType)
                {
                    case PullType.Card:
                        if (cardCount < deck.Cards.Count)
                        {
                            _battlePull.Add(new BattleCard(deck.Cards[_cardPositions[cardCount]]));
                            cardCount++;
                        }
                        else if (trateCount < deck.Trates.Count)
                        {
                            _battlePull.Add(new BattleTrate(deck.Trates[_tratePositions[trateCount]]));
                            trateCount++;
                        }

                        break;
                    case PullType.Trate:
                        if (trateCount < deck.Trates.Count)
                        {
                            _battlePull.Add(new BattleTrate(deck.Trates[_tratePositions[trateCount]]));
                            trateCount++;
                        }
                        else if (cardCount < deck.Cards.Count)
                        {
                            _battlePull.Add(new BattleCard(deck.Cards[_cardPositions[cardCount]]));
                            cardCount++;
                        }

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        

        /// <summary>
        /// Init random unique positions
        /// </summary>
        /// <param name="positions"></param>
        /// <param name="count"></param>
        private static void InitRandomPositions(ICollection<int> positions, int count)
        {
            while (true)
            {
                var randomPos = Random.Range(0, count);
                if (!positions.Contains(randomPos))
                {
                    positions.Add(randomPos);
                }

                if (positions.Count < count)
                {
                    continue;
                }

                break;
            }
        }
    }
}