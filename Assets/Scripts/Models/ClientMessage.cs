using UnityEngine.Networking;

namespace Models
{
    public class ClientMessage : MessageBase
    {
        public string Id;
        public string Name;
        public int Price;
        public int MaxPlayers;
        public int CurrentPlayers;
        public RoomType RoomType;
        public StatusMsg Status;
    }

    public enum RoomType
    {
        Regular,
        Super
    }

    public enum StatusMsg
    {
        Adding,
        Sending,
        Deleting,
        Printing,
        Editing
    }
}