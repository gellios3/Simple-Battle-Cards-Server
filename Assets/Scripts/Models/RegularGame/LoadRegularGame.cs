using System.Xml.Linq;

namespace Models.RegularGame
{
    public class LoadRegularGame : BaseRegularGame
    {
        public LoadRegularGame(XElement data)
        {
            if (data == null) return;
            Name = data.Value;
            Price = (int) data.Attribute("price");
            MaxPlayers = (int) data.Attribute("maxPlayers");
            CurrentPlayers = (int) data.Attribute("players");
        }
    }
}