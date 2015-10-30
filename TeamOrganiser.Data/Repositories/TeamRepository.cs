using System.Collections.Generic;
using TeamOrganiser.Domain;

namespace TeamOrganiser.Data.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        public IEnumerable<Team> GetAllTeamSummaries()
        {
            return new List<Team> {new Team("Team 1", 45), new Team("Team 2", 75)};
        }
    }
}