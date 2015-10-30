namespace TeamOrganiser.Domain
{
    public class Team
    {
        public Team(string teamName, int optimumVelocity)
        {
            TeamName = teamName;
            OptimumVelocity = optimumVelocity;
        }

        public string TeamName { get; private set; }
        public int OptimumVelocity { get; private set; }
    }
}