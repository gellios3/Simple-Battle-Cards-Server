using Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegularRoomManager : MonoBehaviour
{
    public RegularGame Game { private get; set; }

    private void Start()
    {
        // set room name
        gameObject.transform.Find("RoomName").GetComponent<Text>().text = Game.Name;

        // Set room price
        gameObject.transform.Find("RoomPlayers").GetComponent<Text>().text = Game.CurrentPlayers.ToString();

        // Check if room is full
        if (Game.MaxPlayers != Game.CurrentPlayers) return;
        // Deactivate button
        gameObject.transform.Find("JoinButton").GetComponent<Button>().interactable = false;
        gameObject.transform.Find("JoinButton/Text").GetComponent<Text>().text = "full";
    }

    public void loadGameRoom()
    {
        SceneManager.LoadSceneAsync("JoinRoom");
    }
}