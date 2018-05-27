using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Models;
using UnityEngine;

public class RoomsListLoader : MonoBehaviour
{
    /// <summary>
    /// Surer games list
    /// </summary>
    private readonly List<SuperGame> _surerGames = new List<SuperGame>();

    public List<SuperGame> SurerGames
    {
        get { return _surerGames; }
    }

    /// <summary>
    /// Regular games list
    /// </summary>
    private readonly List<RegularGame> _regularGames = new List<RegularGame>();

    public List<RegularGame> RegularGames
    {
        get { return _regularGames; }
    }

    private void Awake()
    {
        // load xml file
        var xDocument = XDocument.Load("./Assets/data.xml");

        // Init regular games
        var xRegularGames = xDocument.Descendants("room").ToArray();
        foreach (var game in xRegularGames)
        {
            RegularGames.Add(new RegularGame(game));
        }

        RegularGames.Sort((a, b) => string.CompareOrdinal(a.Name, b.Name));

        // Init super games
        var xSuperGames = xDocument.Descendants("supergame").ToArray();
        foreach (var game in xSuperGames)
        {
            SurerGames.Add(new SuperGame(game));
        }
    }
}