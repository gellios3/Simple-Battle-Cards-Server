using Commands;
using Models;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using Signals;
using UnityEngine;
using View;

namespace Contexts
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

        // Unbind the default EventCommandBinder and rebind the SignalCommandBinder
        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }

        // 
        /// <summary>
        /// Override Start so that we can fire the StartSignal 
        /// </summary>
        /// <returns></returns>
        public override IContext Start()
        {
            base.Start();

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
            injectionBinder.Bind<LoadRoomListSignal>().ToSingleton();
            injectionBinder.Bind<RoomsFetchedSignal>().ToSingleton();

            injectionBinder.Bind<RoomListData>().ToSingleton();

            commandBinder.Bind<LoadRoomListSignal>().To<FetchRoomListComand>();

            mediationBinder.Bind<RoomsDropdownView>().To<RoomsDropdownMediator>();
            mediationBinder.Bind<RoomGridView>().To<RoomGridViewMediator>();
        }
    }
}