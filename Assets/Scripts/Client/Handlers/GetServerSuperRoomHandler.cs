using Client.Models;
using Models.SuperGame;
using UnityEngine;
using UnityEngine.Networking;

namespace Client.Handlers
{
    public class GetServerSuperRoomHandler : IServerMessageHandler
    {
        public short MessageType => MsgStruct.SuperRoomResponse;

        public void Handle(NetworkMessage msg)
        {
            Debug.Log("GetServerSuperRoomHandler");
            var temp = msg.ReadMessage<SuperGameMessage>();
            Debug.Log(temp.Id);
        }
    }
}