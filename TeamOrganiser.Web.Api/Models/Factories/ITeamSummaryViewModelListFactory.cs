using System.Collections.Generic;

namespace TeamOrganiser.Web.Api.Models.Factories
{
    public interface ITeamSummaryViewModelListFactory
    {
        IList<TeamSummaryViewModel> Create();
    }
}