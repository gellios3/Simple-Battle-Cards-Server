namespace Models.RegularGame
{
    public class BaseRegularGame : IRegularGame
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int MaxPlayers { get; set; }
        public int CurrentPlayers { get; set; }
    }
}