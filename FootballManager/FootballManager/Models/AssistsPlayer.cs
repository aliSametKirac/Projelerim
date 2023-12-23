namespace FootballManager.Models
{
    public class AssistsPlayer
    {
        public int Id { get; set; }
        public int AssistsCount { get; set; }

        //public int MatchId { get; set; }
        public Match Match { get; set; }

        //public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
