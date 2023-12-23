namespace FootballManager.Models
{
    public class TeamSeason
    {
        public int Id { get; set; }
        public Team Team { get; set; }
        public Season Season { get; set; }
    }
}
