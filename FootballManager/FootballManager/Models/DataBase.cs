using Microsoft.EntityFrameworkCore;

namespace FootballManager.Models
{
    public class DataBase : DbContext
    {
        public DataBase(DbContextOptions<DataBase> options) : base(options)
        {
        }

        public virtual DbSet<AssistsPlayer> AssistsPlayers { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<GoolPlayer> GoolPlayers { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamCoach> TeamsCoaches { get; set; }
        public virtual DbSet<TeamPlayer> TeamPlayers { get; set; }
        public virtual DbSet<TeamSeason> TeamSeasons { get; set; }
    }
}
