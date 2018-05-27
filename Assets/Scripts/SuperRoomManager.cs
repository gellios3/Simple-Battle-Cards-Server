using Models;
using UnityEngine;
using UnityEngine.UI;

public class SuperRoomManager : MonoBehaviour
{
    public SuperGame Game { private get; set; }

    // Use this for initialization
    private void Start()
    {
        // Set scroll position 
        gameObject.transform.Find("FillStatus/StatusScrollbar").GetComponent<Scrollbar>().size =
            (float) Game.CurrentPlayers / Game.MaxPlayers;

        // Set current players
        gameObject.transform.Find("FillStatus/HUD/CurrentPlayersTxt").GetComponent<Text>().text =
            Game.CurrentPlayers.ToString();

        // Set max payers
        gameObject.transform.Find("FillStatus/HUD/MaxPlayersTxt").GetComponent<Text>().text =
            Game.MaxPlayers.ToString();

        // Set room price
        gameObject.transform.Find("RoomPrice").GetComponent<Text>().text = Game.Price.ToString();
    }
}