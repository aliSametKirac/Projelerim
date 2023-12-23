namespace FootballManager.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TeamCoach> TeamCoaches { get; set; }
        public virtual ICollection<TeamPlayer> TeamPlayers { get; set; }
        public virtual ICollection<TeamSeason> TeamSeasons { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
