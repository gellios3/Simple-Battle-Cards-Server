using Models;
using UnityEngine;

public class RoomGridManager : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
        var roomList = gameObject.GetComponentInParent<RoomsListLoader>();

        // init super rooms
        foreach (var game in roomList.SurerGames)
        {
            var superRoom = (GameObject) Instantiate(
                Resources.Load("Prefabs/SuperRoom", typeof(GameObject)), new Vector2(), Quaternion.identity, transform
            );
            superRoom.GetComponent<SuperRoomManager>().Game = game;
        }

        // init regular rooms
        foreach (var game in roomList.RegularGames)
        {
            var regularRoom = (GameObject) Instantiate(
                Resources.Load("Prefabs/RegularRoom", typeof(GameObject)), new Vector2(), Quaternion.identity, transform
            );
            regularRoom.GetComponent<RegularRoomManager>().Game = game;
        }
    }
}