using Boo.Lang;
using Models;

namespace Server.Services
{
    public class NetworkLobbyService
    {
        public List<NetworkPlayer> Players { get; } = new List<NetworkPlayer>();
    }
}