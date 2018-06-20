using UnityEngine.Networking;

namespace Models.SuperGame
{
    public class SuperGameMessage : MessageBase
    {
        public string Id;
        public int Price;
        public int MaxPlayers;
        public int CurrentPlayers;
    }
}