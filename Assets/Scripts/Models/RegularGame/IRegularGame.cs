namespace Models.RegularGame
{
    public interface IRegularGame
    {
        string Name { get; set; }
        int Price { get; set; }
        int MaxPlayers { get; set; }
        int CurrentPlayers { get; set; }
    }
}