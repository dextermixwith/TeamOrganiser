using System.Collections.Generic;
using System.Linq;
using TeamOrganiser.Data.Repositories.Factories;

namespace TeamOrganiser.Web.Api.Models.Factories
{
    public class TeamSummaryViewModelListFactory : ITeamSummaryViewModelListFactory
    {
        private readonly ITeamRepositoryFactory _teamRepositoryFactory;

        public TeamSummaryViewModelListFactory(ITeamRepositoryFactory teamRepositoryFactory)
        {
            _teamRepositoryFactory = teamRepositoryFactory;
        }

        public IList<TeamSummaryViewModel> Create()
        {
            var teamRepository = _teamRepositoryFactory.Create();
            var teams = teamRepository.GetAllTeamSummaries();

            return teams
                .Select(team => new TeamSummaryViewModel(team.TeamName, team.OptimumVelocity))
                .ToList();
        }
    }
}