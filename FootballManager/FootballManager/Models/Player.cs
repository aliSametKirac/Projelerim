namespace FootballManager.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }

        public virtual ICollection<AssistsPlayer> AssistsPlayers { get; set; }
        public virtual ICollection<GoolPlayer> GoolPlayers { get; set; }
        public virtual ICollection<TeamPlayer> TeamPlayers { get; set; }
    }
}
