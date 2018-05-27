using UnityEngine;
using UnityEngine.UI;

public class RomsDropdownManager : MonoBehaviour
{
    // Use this for initialization
    private void Awake()
    {
        // init dropdown options
        var roomList = gameObject.GetComponentInParent<RoomsListLoader>();
        GetComponent<Dropdown>().options.Clear();
        foreach (var game in roomList.RegularGames)
        {
            GetComponent<Dropdown>().options.Add(new Dropdown.OptionData(game.Name));
        }
    }
}