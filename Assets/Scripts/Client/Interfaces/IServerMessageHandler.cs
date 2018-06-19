using UnityEngine.Networking;

namespace Client
{
    public interface IServerMessageHandler
    {
        short MessageType { get; }
        void Handle(NetworkMessage msg);
    }
}