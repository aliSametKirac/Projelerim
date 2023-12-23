namespace FootballManager.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int HomeTeamID { get; set; }
        public int AwayID { get; set; }
        public DateTime MatchDate { get; set;}
        public Team Team { get; set; }

        public virtual ICollection<AssistsPlayer> AssistsPlayers { get; set; }
        public virtual ICollection<GoolPlayer> GoolPlayers { get; set; }
    }
}
