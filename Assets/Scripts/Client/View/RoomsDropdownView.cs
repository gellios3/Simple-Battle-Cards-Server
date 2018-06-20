using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;
using View;

namespace Client.View
{
    public class RoomsDropdownView : EventView
    {
        /// <summary>
        /// Text dropdown label
        /// </summary>
        [SerializeField] private Text _dropdownLabel;

        /// <summary>
        /// On enable view
        /// </summary>
        private void OnEnable()
        {
            GetComponent<Dropdown>().onValueChanged.AddListener(OnCurrentGameChanged);
        }

        /// <summary>
        /// On disable view
        /// </summary>
        private void OnDisable()
        {
            GetComponent<Dropdown>().onValueChanged.RemoveAllListeners();
        }

        /// <summary>
        /// On current game changed
        /// </summary>
        /// <param name="index"></param>
        private void OnCurrentGameChanged(int index)
        {
            Debug.Log(index);
        }

//        /// <summary>
//        /// On rooms fetched
//        /// </summary>
//        /// <param name="gamesSyncList"></param>
//        public void OnRoomsFetched(GamesSyncList gamesSyncList)
//        {
//            GetComponent<Dropdown>().ClearOptions();
//            // init dropdown options
//            foreach (var game in gamesSyncList.RegularGames)
//            {
//                GetComponent<Dropdown>().options.Add(new Dropdown.OptionData(game.Name));
//            }
//
//            // set firt option as label
//            _dropdownLabel.text = GetComponent<Dropdown>().options[0].text;
//        }
    }

    /// <summary>
    /// Room grid view mediator
    /// </summary>
    public class RoomsDropdownMediator : TargetMediator<RoomsDropdownView>
    {
        /// <summary>
        /// Rooms fetch signal
        /// </summary>
//        [Inject]public RoomsFetchedSignal RoomsFetchedSignal { get; set; }

        /// <summary>
        /// Room list data
        /// </summary>
//        [Inject]
//        public GamesSyncList GamesSyncList { get; set; }

        /// <summary>
        /// On register
        /// </summary>
        public override void OnRegister()
        {
//            RoomsFetchedSignal.AddListener(OnRoomsFetched);
        }

        /// <summary>
        /// On rooms fetched
        /// </summary>
        private void OnRoomsFetched()
        {
//            View.OnRoomsFetched(GamesSyncList);
        }
    }
}