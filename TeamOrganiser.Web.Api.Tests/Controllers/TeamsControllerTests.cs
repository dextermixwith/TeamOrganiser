using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TeamOrganiser.Data.Repositories;
using TeamOrganiser.Data.Repositories.Factories;
using TeamOrganiser.Domain;
using TeamOrganiser.Web.Api.Controllers;
using TeamOrganiser.Web.Api.Models;
using TeamOrganiser.Web.Api.Models.Factories;

namespace TeamOrganiser.Web.Api.Tests.Controllers
{
    [TestFixture]
    public class TeamsControllerTests
    {
        private Mock<ITeamRepositoryFactory> _mockTeamRespositoryFactory;
        private Mock<ITeamRepository> _mockTeamRepository;
        private TeamSummaryViewModel[] _result;
        private string _teamName1;
        private string _teamName2;
        private int _optimumVelocity1;
        private int _optimumVelocity2;
        private Mock<ITeamSummaryViewModelListFactory> _mockTeamSummaryViewModelListFactory;
        private List<TeamSummaryViewModel> _teamSummaryViewModelList;

        [SetUp]
        public void GivenATeamController_WhenTeams()
        {
            _teamName1 = "skjdalkjhdsa";
            _teamName2 = "kjsdnaushdsuouishdou";
            _optimumVelocity1 = 60;
            _optimumVelocity2 = 45;

            var teams = new List<Team>
            {
                new Team(_teamName1, _optimumVelocity1),
                new Team(_teamName2, _optimumVelocity2)
            };

            _teamSummaryViewModelList = new List<TeamSummaryViewModel>
            {
                new TeamSummaryViewModel(_teamName1,_optimumVelocity1),
                new TeamSummaryViewModel(_teamName2,_optimumVelocity2)
            };

            _mockTeamRepository = new Mock<ITeamRepository>();

            _mockTeamRespositoryFactory = new Mock<ITeamRepositoryFactory>();
            _mockTeamRespositoryFactory
                .Setup(factory => factory.Create())
                .Returns(_mockTeamRepository.Object);

            _mockTeamRepository
                .Setup(repository => repository.GetAllTeamSummaries())
                .Returns(teams);

            _mockTeamSummaryViewModelListFactory = new Mock<ITeamSummaryViewModelListFactory>();
            _mockTeamSummaryViewModelListFactory
                .Setup(factory => factory.Create())
                .Returns(_teamSummaryViewModelList);

            _result = new TeamsController(_mockTeamSummaryViewModelListFactory.Object).Get();
        }

        [Test]
        public void ThenTheTeamSummaryViewModelIsCreated()
        {
            _mockTeamSummaryViewModelListFactory.Verify(factory => factory.Create());
        }

        [Test]
        public void ThenATeamsListIsReturned()
        {
            Assert.That(_result, Is.EqualTo(_teamSummaryViewModelList.ToArray()));
        }
    }
}
