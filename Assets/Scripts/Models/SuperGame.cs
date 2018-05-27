using System.Xml.Linq;

namespace Models
{
    public class SuperGame
    {
        public int Price { get; private set; }
        public int MaxPlayers { get; private set; }
        public int CurrentPlayers { get; private set; }

        public SuperGame(XElement data)
        {
            Price = (int) data.Attribute("price");
            MaxPlayers = (int) data.Attribute("max");
            CurrentPlayers = (int) data.Attribute("current");
        }
    }
}