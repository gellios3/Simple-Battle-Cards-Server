using UnityEngine.Networking;

namespace Models.RegularGame
{
    public class RegularGameMessage : MessageBase
    {
        public string Id;
        public string Name;
        public int Price;
        public int MaxPlayers;
        public int CurrentPlayers;
    }
}