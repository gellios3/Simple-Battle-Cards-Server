using Models.RegularGame;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Client.View
{
    public class RegularRoomView : MonoBehaviour
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

        /// <summary>
        /// Init regular room view
        /// </summary>
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
                _joinButton.OnClickAsObservable().Subscribe(p => { SceneManager.LoadSceneAsync("JoinRoom"); });
            }
        }
    }
}