using System.Linq;
using System.Web.Http;
using TeamOrganiser.Web.Api.Models;
using TeamOrganiser.Web.Api.Models.Factories;

namespace TeamOrganiser.Web.Api.Controllers
{
    public class TeamsController : ApiController
    {
        private readonly ITeamSummaryViewModelListFactory _teamSummaryViewModelListFactory;

        public TeamsController(ITeamSummaryViewModelListFactory teamSummaryViewModelListFactory)
        {
            _teamSummaryViewModelListFactory = teamSummaryViewModelListFactory;
        }

        public TeamSummaryViewModel[] Get()
        {

            var teamViewSUmmaryModels = _teamSummaryViewModelListFactory.Create();

            return teamViewSUmmaryModels.ToArray();
 
        }
    }
}
