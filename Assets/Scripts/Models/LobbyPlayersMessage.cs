using UnityEngine.Networking;

namespace Models
{
    public class LobbyPlayersMessage  : MessageBase
    {
        public PlayerStruct[] Players;
    }
}