using System.Collections.Generic;
using strange.extensions.mediation.impl;
using Server.Handlers;
using Server.Interfaces;
using Server.Services;
using View;

namespace Server.Views
{
    public class ChatView : EventView, IServerFeature
    {
        [Inject] public PlayerMessageHandler PlayerMessageHandler { get; set; }

        /// <summary>
        /// Handlers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IServerHandler> Handlers()
        {
            return new List<IServerHandler>
            {
                PlayerMessageHandler
            };
        }
    }


    /// <summary>
    /// Chat view mediator
    /// </summary>
    public class ChatViewMediator : TargetMediator<ChatView>
    {
        [Inject] public GameServerService GameServerServiceConnector { get; set; }

        public override void OnRegister()
        {
            GameServerServiceConnector.RegisterFeatureHandlers(new List<IServerFeature> {View});
        }
    }
}