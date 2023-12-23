namespace FootballManager.Models
{
    public class Coach
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<TeamCoach> TeamCoaches { get; set; }
    }
}
