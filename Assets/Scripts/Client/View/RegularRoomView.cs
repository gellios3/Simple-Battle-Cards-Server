using Client.Models;
using Client.Signals;
using Models;
using Models.RegularGame;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
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
        public BaseRegularGame Game { private get; set; }

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

        [Inject] public ServerUpdateRegularGameSignal ServerUpdateRegularGameSignal { get; set; }

        [Inject] public IEvent buttonClicked { get; set; }

        [Inject(ContextKeys.CONTEXT_DISPATCHER)]
        IEventDispatcher dispatcher { get; set; }

        private void Start()
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
                dispatcher.AddListener(buttonClicked, () =>
                {
                    Debug.Log("buttonClicked");
                    ServerUpdateRegularGameSignal.Dispatch(Game);
                    SceneManager.LoadSceneAsync("JoinRoom", LoadSceneMode.Additive);
                });
                _joinButton.OnClickAsObservable().Subscribe(p => { dispatcher.Dispatch(buttonClicked); });
            }
        }
    }

    public class RegularRoomViewMediator : TargetMediator<RegularRoomView>
    {
        public override void OnRegister()
        {
        }
    }
}