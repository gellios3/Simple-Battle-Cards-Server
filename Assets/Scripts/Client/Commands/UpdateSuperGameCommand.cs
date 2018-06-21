using Client.Signals;
using Models;
using Models.SuperGame;
using strange.extensions.command.impl;

namespace Client.Commands
{
    public class UpdateSuperGameCommand : Command
    {
        /// <summary>
        /// Base regular game
        /// </summary>
        [Inject]
        public BaseSuperGame SuperGame { get; set; }

        /// <summary>
        /// Room list data
        /// </summary>
        [Inject]
        public RoomsListData RoomsListData { get; set; }

        /// <summary>
        /// Add super game view signal
        /// </summary>
        [Inject]
        public AddSuperGameViewSignal AddSuperGameViewSignal { get; set; }

        /// <summary>
        /// Execute add super game signal
        /// </summary>
        public override void Execute()
        {
            var index = RoomsListData.SuperGames.FindIndex(
                game => SuperGame.Id == game.Id
            );
            if (index > 0)
            {
                RoomsListData.SuperGames[index] = SuperGame;
            }
            else
            {
                RoomsListData.SuperGames.Add(SuperGame);
                AddSuperGameViewSignal.Dispatch(SuperGame);
            }
        }
    }
}