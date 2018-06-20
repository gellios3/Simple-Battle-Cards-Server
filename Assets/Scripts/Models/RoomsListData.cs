using System.Collections.Generic;
using Models.RegularGame;
using Models.SuperGame;

namespace Models
{
    public class RoomsListData
    {
        /// <summary>
        /// Super games
        /// </summary>
        public List<BaseSuperGame> SuperGames { get; set; } = new List<BaseSuperGame>();

        /// <summary>
        /// Regular games
        /// </summary>
        public List<BaseRegularGame> RegularGames { get; set; } = new List<BaseRegularGame>();
    }
}