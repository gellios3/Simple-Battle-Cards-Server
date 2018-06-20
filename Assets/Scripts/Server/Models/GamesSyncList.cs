using Models.RegularGame;
using Models.SuperGame;
using UnityEngine;

namespace Server.Models
{
    public class GamesSyncList
    {
        /// <summary>
        /// Regular games list
        /// </summary>
        [SerializeField] private readonly RegularGameSyncList _regularGames = new RegularGameSyncList();

        public RegularGameSyncList RegularGames => _regularGames;

        /// <summary>
        /// Surer games list
        /// </summary>
        [SerializeField] private readonly SuperGameSynclist _surerGames = new SuperGameSynclist();

        public SuperGameSynclist SurerGames => _surerGames;
    }
}