using System.Xml.Linq;

namespace Models
{
    public class RegularGame
    {
        public string Name { get; }
        public int Price { get; }
        public int MaxPlayers { get; }
        public int CurrentPlayers { get; }

        public RegularGame(XElement data)
        {
            if (data == null) return;
            Name = data.Value;
            Price = (int) data.Attribute("price");
            MaxPlayers = (int) data.Attribute("maxPlayers");
            CurrentPlayers = (int) data.Attribute("players");
        }
    }
}