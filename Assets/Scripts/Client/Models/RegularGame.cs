using System.Xml.Linq;

namespace Models
{
    public class RegularGame
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public int MaxPlayers { get; private set; }
        public int CurrentPlayers { get; private set; }

        public RegularGame(XElement data)
        {
            Name = data.Value;
            Price = (int) data.Attribute("price");
            MaxPlayers = (int) data.Attribute("maxPlayers");
            CurrentPlayers = (int) data.Attribute("players");
        }
    }
}