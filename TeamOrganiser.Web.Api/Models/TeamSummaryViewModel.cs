namespace TeamOrganiser.Web.Api.Models
{
    public class TeamSummaryViewModel
    {
        public TeamSummaryViewModel(string teamName, int optimumVelocity)
        {
            TeamName = teamName;
            OptimumVelocity = optimumVelocity;
        }

        public string TeamName { get; private set; }
        public int OptimumVelocity { get; private set; }
    }
}