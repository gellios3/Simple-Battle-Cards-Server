using System.Xml.Linq;

namespace Models
{
    public class SuperGame
    {
        public int Price { get; }
        public int MaxPlayers { get; }
        public int CurrentPlayers { get; }

        public SuperGame(XElement data)
        {
            Price = (int) data.Attribute("price");
            MaxPlayers = (int) data.Attribute("max");
            CurrentPlayers = (int) data.Attribute("current");
        }
    }
}