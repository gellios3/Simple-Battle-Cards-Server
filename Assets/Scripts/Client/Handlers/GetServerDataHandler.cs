using System.Collections.Generic;
using Client.Models;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

namespace Client.Handlers
{
    public class GetServerDataHandler : IServerMessageHandler
    {
        public short MessageType => MsgStruct.EchoServerResponse;

        public List<string> ServerResponses { get; } = new List<string>();

        public void Handle(NetworkMessage msg)
        {
            var temp = msg.ReadMessage<StringMessage>().value;
            Debug.Log(temp);
            ServerResponses.Add(temp);
        }
    }
}