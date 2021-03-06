﻿using Client.Commands;
using Client.Signals;
using Client.View;
using Models;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

namespace Client.Contexts
{
    public class AppContext : MVCSContext
    {
        public AppContext(MonoBehaviour view) : base(view)
        {
            _instance = this;
        }

        public AppContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {
            _instance = this;
        }

        private static AppContext _instance;

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
            var startSignal = injectionBinder.GetInstance<LoadGameDataSignal>();
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
            injectionBinder.Bind<DisonnectedFromServerSignal>().ToSingleton();
            injectionBinder.Bind<AddRegularGameViewSignal>().ToSingleton();
            injectionBinder.Bind<AddSuperGameViewSignal>().ToSingleton();
            injectionBinder.Bind<UpdateRegularGameViewSignal>().ToSingleton();
            injectionBinder.Bind<ServerUpdateRegularGameSignal>().ToSingleton();

            //Bind Services
//            injectionBinder.Bind<RoomsListData>().ToSingleton();
            injectionBinder.Bind<ServerConnectorService>().ToSingleton();
//            injectionBinder.Bind<GetServerRegularRoomHandler>().ToSingleton();
//            injectionBinder.Bind<GetServerSuperRoomHandler>().ToSingleton();

            // Bind Commads
            commandBinder.Bind<LoadGameDataSignal>().To<LoadGameDataCommand>();
            commandBinder.Bind<ServerConnectedResultSignal>().To<ServerConectedCommand>();
//            commandBinder.Bind<UpdateRegularGameDataSignal>().To<UpdateRegularGameCommand>();
//            commandBinder.Bind<UpdateSuperGameDataSignal>().To<UpdateSuperGameCommand>();
            commandBinder.Bind<ServerUpdateRegularGameSignal>().To<ServerUpdateRegularGameCommand>();

            //Bind Views
            mediationBinder.Bind<RoomsDropdownView>().To<RoomsDropdownMediator>();
            mediationBinder.Bind<RoomListView>().To<RoomGridViewMediator>();
            mediationBinder.Bind<RegularRoomView>().To<RegularRoomViewMediator>();
        }
    }
}