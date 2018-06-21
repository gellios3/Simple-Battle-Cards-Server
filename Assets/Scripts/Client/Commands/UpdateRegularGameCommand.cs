using Client.Signals;
using Models;
using Models.RegularGame;
using strange.extensions.command.impl;

namespace Client.Commands
{
    public class UpdateRegularGameCommand : Command
    {
        /// <summary>
        /// Base regular game
        /// </summary>
        [Inject]
        public BaseRegularGame RegularGame { get; set; }

        /// <summary>
        /// Room list data
        /// </summary>
        [Inject]
        public RoomsListData RoomsListData { get; set; }

        /// <summary>
        /// Update room list view signal
        /// </summary>
        [Inject]
        public AddRegularGameViewSignal AddRegularGameViewSignal { get; set; }

        /// <summary>
        /// Update regular game view signal
        /// </summary>
        [Inject]
        public UpdateRegularGameViewSignal UpdateRegularGameViewSignal { get; set; }

        /// <summary>
        /// Execute update regular games signal
        /// </summary>
        public override void Execute()
        {
            var index = RoomsListData.RegularGames.FindIndex(
                game => RegularGame.Id == game.Id
            );
            if (index > 0)
            {
                RoomsListData.RegularGames[index] = RegularGame;
                UpdateRegularGameViewSignal.Dispatch(RegularGame);
            }
            else
            {
                RoomsListData.RegularGames.Add(RegularGame);
                AddRegularGameViewSignal.Dispatch(RegularGame);
            }
        }
    }
}