using strange.extensions.command.impl;
using UnityEngine.Networking;

namespace Server.Commands
{
    public class OnListeningServerCommand : Command
    {
        /// <summary>
        /// Game serverService connector
        /// </summary>
        [Inject] public GameServerService GameServerServiceConnector { get; set; }
        
        public override void Execute()
        {
            NetworkServer.RegisterHandler(MsgType.Connect, GameServerServiceConnector.OnConnectToServer);
            NetworkServer.RegisterHandler(MsgType.Disconnect, GameServerServiceConnector.OnDisconnectFromServer);
            NetworkServer.RegisterHandler(MsgType.Error, GameServerServiceConnector.OnServerErrorMethod);
        }
    }
}