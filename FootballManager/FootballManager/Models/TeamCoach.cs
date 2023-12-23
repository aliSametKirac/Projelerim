namespace FootballManager.Models
{
    public class TeamCoach
    {
        public int Id { get; set; }

        //public int TeamId { get; set; }
        public Team Team { get; set; }

        //public int CoachId { get; set; }
        public Coach Coach { get; set; }

        //public int SeasonId { get; set; }
        public Season Season { get; set; }
    }
}
