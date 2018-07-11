using Boo.Lang;
using Models;

namespace Server.Services
{
    public class NetworkLobbyService
    {
        public List<PlayerStruct> Players { get; } = new List<PlayerStruct>();
    }
}