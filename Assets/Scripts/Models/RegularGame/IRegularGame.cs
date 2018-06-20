namespace Models.RegularGame
{
    public interface IRegularGame
    {
        string Id { get; set; }
        string Name { get; set; }
        int Price { get; set; }
        int MaxPlayers { get; set; }
        int CurrentPlayers { get; set; }
    }
}