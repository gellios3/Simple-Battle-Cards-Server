namespace Models
{
    public interface ISuperGame
    {
        string Id { get; set; }
        int Price { get; set; }
        int MaxPlayers { get; set; }
        int CurrentPlayers { get; set; }
    }
}