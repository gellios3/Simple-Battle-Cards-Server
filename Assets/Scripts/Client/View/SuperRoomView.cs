using Models.SuperGame;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class SuperRoomView : MonoBehaviour
    {
        /// <summary>
        /// Super game
        /// </summary>
        public BaseSuperGame Game { private get; set; }

        /// <summary>
        /// Status scrollbar
        /// </summary>
        [SerializeField] private Scrollbar _statusScrollbar;
        
        /// <summary>
        /// Current players text count 
        /// </summary>
        [SerializeField] private Text _currentPlayersTxt;
        
        /// <summary>
        /// Max players text count
        /// </summary>
        [SerializeField] private Text _maxPlayersTxt;
        
        /// <summary>
        /// Room price
        /// </summary>
        [SerializeField] private Text _roomPrice;

        /// <summary>
        /// Super room init view
        /// </summary>
        private void Start()
        {
            // Set scroll position 
            _statusScrollbar.size = (float) Game.CurrentPlayers / Game.MaxPlayers;
            // Set current players
            _currentPlayersTxt.GetComponent<Text>().text = Game.CurrentPlayers.ToString();
            // Set max payers
            _maxPlayersTxt.text = Game.MaxPlayers.ToString();
            // Set room price
            _roomPrice.text = Game.Price.ToString();
        }
    }
}