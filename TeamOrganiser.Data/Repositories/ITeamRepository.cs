using System.Collections.Generic;
using TeamOrganiser.Domain;

namespace TeamOrganiser.Data.Repositories
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetAllTeamSummaries();
    }
}