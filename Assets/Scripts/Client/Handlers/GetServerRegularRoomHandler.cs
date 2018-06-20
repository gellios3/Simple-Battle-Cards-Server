using Client.Models;
using Models.RegularGame;
using UnityEngine;
using UnityEngine.Networking;

namespace Client.Handlers
{
    public class GetServerRegularRoomHandler : IServerMessageHandler
    {
        public short MessageType => MsgStruct.RegularRoomResponse;

        public void Handle(NetworkMessage msg)
        {
            var temp = msg.ReadMessage<RegularGameMessage>();
            Debug.Log(temp.Id);
        }
    }
}