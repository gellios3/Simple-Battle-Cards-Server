using UnityEngine.Networking;

namespace Models.Messages
{
    public class LobbyPlayersMessage  : MessageBase
    {
        public NetworkPlayer[] NetworkPlayers;
    }
}