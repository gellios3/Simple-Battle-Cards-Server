using Client.Signals;
using Models.RegularGame;
using strange.extensions.mediation.impl;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using View;

namespace Client.View
{
    public class RegularRoomView : EventView
    {
        /// <summary>
        /// REgular game
        /// </summary>
        public BaseRegularGame Game { get; set; }

        /// <summary>
        /// Room name text 
        /// </summary>
        [SerializeField] private Text _roomName;

        /// <summary>
        /// Players count text
        /// </summary>
        [SerializeField] private Text _roomPlayers;

        /// <summary>
        /// Join button
        /// </summary>
        [SerializeField] private Button _joinButton;

        /// <summary>
        /// Join button text
        /// </summary>
        [SerializeField] private Text _joinButtonTxt;

        /// <summary>
        /// Server updateRegularGameSignal
        /// </summary>
        public ServerUpdateRegularGameSignal ServerUpdateRegularGameSignal { get; set; }

        public void InitGame()
        {
            // set room name
            _roomName.text = Game.Name;
            // Set room price
            _roomPlayers.text = Game.CurrentPlayers.ToString();

            // Check if room is full
            if (Game.MaxPlayers == Game.CurrentPlayers)
            {
                // Deactivate button
                _joinButton.interactable = false;
                // @todo localizate text
                _joinButtonTxt.text = "full";
            }
            else
            {
                // @todo Fix this
                _joinButton.OnClickAsObservable().ObserveOnMainThread().Subscribe(p =>
                {
                    ServerUpdateRegularGameSignal.Dispatch(Game);
                    SceneManager.LoadSceneAsync("JoinRoom", LoadSceneMode.Additive);
                });
            }
        }

        private void Start()
        {
            InitGame();
        }
    }

    public class RegularRoomViewMediator : TargetMediator<RegularRoomView>
    {
        public override void OnRegister()
        {
        }
    }
}