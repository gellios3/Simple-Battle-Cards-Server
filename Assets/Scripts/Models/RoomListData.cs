using System.Collections.Generic;

namespace Models
{
    public class RoomListData
    {
        /// <summary>
        /// Surer games list
        /// </summary>
        public List<SuperGame> SurerGames { get; } = new List<SuperGame>();

        /// <summary>
        /// Regular games list
        /// </summary>
        public List<RegularGame> RegularGames { get; } = new List<RegularGame>();
    }
}