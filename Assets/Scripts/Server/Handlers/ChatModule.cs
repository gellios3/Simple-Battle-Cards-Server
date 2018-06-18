using System.Collections.Generic;
using UnityEngine;

namespace Server.Handlers
{
    public class ChatModule : MonoBehaviour, IServerFeature
    {
        private NetworkingGameServer _gameServerConnector;

        public IEnumerable<IServerHandler> Handlers()
        {
            return new List<IServerHandler>
            {
                new ChatPrintHandler(_gameServerConnector),
                new ChatMessageHandler(_gameServerConnector)
            };
        }

        private void Awake()
        {
            _gameServerConnector = GetComponent<NetworkingGameServer>();
            _gameServerConnector.RegisterFeatureHandlers(new List<IServerFeature> {this});
        }
    }
}