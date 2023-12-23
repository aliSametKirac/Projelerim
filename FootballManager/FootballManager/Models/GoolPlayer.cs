namespace FootballManager.Models
{
    public class GoolPlayer
    {
        public int Id { get; set; }
        public int GoalCount { get; set; }

        //public int MatchId { get; set; }
        public Match Match { get; set; }

        //public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
