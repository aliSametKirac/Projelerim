namespace FootballManager.Models
{
    public class TeamPlayer
    {
        public int Id { get; set; }

        //public int TeamId { get; set; }
        public Team Team { get; set; }

        //public int PlayerId { get; set; }
        public Player Player { get; set; }

        //public int SeasonId { get; set; }
        public Season Season { get; set; }
    }
}
