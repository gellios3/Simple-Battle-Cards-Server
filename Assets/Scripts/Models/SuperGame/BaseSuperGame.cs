namespace Models.SuperGame
{
    public class BaseSuperGame : ISuperGame
    {
        public string Id { get; set; }
        public int Price { get; set; }
        public int MaxPlayers { get; set; }
        public int CurrentPlayers { get; set; }
    }
}