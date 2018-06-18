using System.Collections.Generic;

namespace Models
{
    public class RoomListData
    {
        /// <summary>
        /// Surer games list
        /// </summary>
        private List<SuperGame> _surerGames = new List<SuperGame>();

        /// <summary>
        /// Surer games list
        /// </summary>
        public List<SuperGame> SurerGames
        {
            get { return _surerGames; }
            set { _surerGames = value; }
        }

        /// <summary>
        /// Regular games list
        /// </summary>
        private List<RegularGame> _regularGames = new List<RegularGame>();

        /// <summary>
        /// Regular games list
        /// </summary>
        public List<RegularGame> RegularGames
        {
            get { return _regularGames; }
            set { _regularGames = value; }
        }
    }
}