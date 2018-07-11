using UnityEngine.Networking;

namespace Models
{
    public class PlayerMessage : MessageBase
    {
        public int Id;
        public string Name;
        public bool IsConnected;
    }
}