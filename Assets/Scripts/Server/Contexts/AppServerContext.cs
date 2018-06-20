using Models;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using Server.Commands;
using Server.Handlers;
using Server.Models;
using Server.Signals;
using Server.Views;
using UnityEngine;

namespace Server.Contexts
{
    public class AppServerContext : MVCSContext
    {
        public AppServerContext(MonoBehaviour view) : base(view)
        {
            _instance = this;
        }

        public AppServerContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {
            _instance = this;
        }

        private static AppServerContext _instance;

        public static T Get<T>()
        {
            return _instance.injectionBinder.GetInstance<T>();
        }

        /// <inheritdoc />
        /// <summary>
        /// Unbind the default EventCommandBinder and rebind the SignalCommandBinder
        /// </summary>
        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }

        /// <summary>
        /// Override Start so that we can fire the StartSignal 
        /// </summary>
        /// <returns></returns>
        public override IContext Start()
        {
            base.Start();

//            var startSignal = injectionBinder.GetInstance<StartListeningServerSignal>();
            var startSignal = injectionBinder.GetInstance<LoadRoomListSignal>();
            startSignal.Dispatch();

            return this;
        }

        /// <inheritdoc />
        /// <summary>
        /// Ovverade Bindings map
        /// </summary>
        protected override void mapBindings()
        {
            // Bind Signals
            injectionBinder.Bind<LoadRoomListSignal>().ToSingleton();
            injectionBinder.Bind<ServerConnectedSignal>().ToSingleton();
            injectionBinder.Bind<StartListeningServerSignal>().ToSingleton();
            injectionBinder.Bind<ServerErrorSignal>().ToSingleton();
            injectionBinder.Bind<DisconnectSignal>().ToSingleton();
            injectionBinder.Bind<SendMessageSignal>().ToSingleton();
            injectionBinder.Bind<StartServerSignal>().ToSingleton();

            // Bind Services
            injectionBinder.Bind<GameServerService>().ToSingleton();
            injectionBinder.Bind<ChatMessageHandler>().ToSingleton();
            injectionBinder.Bind<GamesSyncList>().ToSingleton();
            injectionBinder.Bind<RoomsListData>().ToSingleton();

            // Bind Commands
            commandBinder.Bind<StartListeningServerSignal>().To<StartListeningCommand>();
            commandBinder.Bind<SendMessageSignal>().To<SendMessageCommand>();
            commandBinder.Bind<LoadRoomListSignal>().To<FetchRoomListCommand>();
            commandBinder.Bind<StartServerSignal>().To<StartServerCommand>();
            commandBinder.Bind<ServerConnectedSignal>().To<ServerConnectedCommand>();

            // Bind Views   
            mediationBinder.Bind<ServerView>().To<ServerViewMediator>();
            mediationBinder.Bind<ChatView>().To<ChatViewMediator>();
        }
    }
}