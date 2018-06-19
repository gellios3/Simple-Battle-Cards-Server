using Client.Models;
using Models.RegularGame;
using UnityEngine;
using UnityEngine.Networking;

namespace Client.Handlers
{
    public class GetServerDataHandler : IServerMessageHandler
    {
        public short MessageType => MsgStruct.EchoServerResponse;

//        public List<RoomListStruct> ServerResponses { get; } = new List<RoomListStruct>();

        public void Handle(NetworkMessage msg)
        {
            var temp = msg.ReadMessage<RegularGameMessage>();
            Debug.Log(temp.Name);

//            ServerResponses.Add(new RoomListStruct
//            {
//                RegularGames = temp.RegularGames,
//                SurerGames = temp.SurerGames
//            });
        }
    }
}