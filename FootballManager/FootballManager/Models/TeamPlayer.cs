namespace FootballManager.Models
{
    public class TeamPlayer
    {
        public int Id { get; set; }
        public Team Team { get; set; }
        public Player Player { get; set; }
        public Season Season { get; set; }
    }
}
