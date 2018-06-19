using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Models
{
    public class RoomListMessage : MessageBase
    {
//        public List<SuperGame> SurerGames;
        public List<RegularGameStruct> RegularGames;

    }
}