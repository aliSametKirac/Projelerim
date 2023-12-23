namespace FootballManager.Models
{
    public class TeamCoach
    {
        public int Id { get; set; }
        public Team Team { get; set; }
        public Coach Coach { get; set; }
        public Season Season { get; set; }
    }
}
