using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TeamOrganiser.Data.Repositories;
using TeamOrganiser.Data.Repositories.Factories;
using TeamOrganiser.Domain;
using TeamOrganiser.Web.Api.Models;
using TeamOrganiser.Web.Api.Models.Factories;

namespace TeamOrganiser.Web.Api.Tests.Models.Factories
{
    [TestFixture]
    public class TeamSummaryViewModelListFactoryTests
    {
        private Mock<ITeamRepositoryFactory> _mockTeamRespositoryFactory;
        private Mock<ITeamRepository> _mockTeamRepository;
        private IList<TeamSummaryViewModel> _result;
        private string _teamName1;
        private string _teamName2;
        private int _optimumVelocity1;
        private int _optimumVelocity2;

        [SetUp]
        public void GivenATeamViewSummaryViewModelFactory_WhenCreate()
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

 
            _mockTeamRepository = new Mock<ITeamRepository>();

            _mockTeamRespositoryFactory = new Mock<ITeamRepositoryFactory>();
            _mockTeamRespositoryFactory
                .Setup(factory => factory.Create())
                .Returns(_mockTeamRepository.Object);

            _mockTeamRepository
                .Setup(repository => repository.GetAllTeamSummaries())
                .Returns(teams);

            _result = new TeamSummaryViewModelListFactory(_mockTeamRespositoryFactory.Object).Create();
        }

        [Test]
        public void ThenATeamRepositoryIsCreated()
        {
            _mockTeamRespositoryFactory.Verify(factory => factory.Create());
        }

        [Test]
        public void ThenAListOfTeamSummariesIsFetched()
        {
            _mockTeamRepository.Verify(repository => repository.GetAllTeamSummaries());
        }

        [Test]
        public void ThenTheTeamNamesAreCorrect()
        {
            Assert.That(_result[0].TeamName, Is.EqualTo(_teamName1));
            Assert.That(_result[1].TeamName, Is.EqualTo(_teamName2));
        }

        [Test]
        public void ThenTheTeamOptimumVelocitiesAreCorrect()
        {
            Assert.That(_result[0].OptimumVelocity, Is.EqualTo(_optimumVelocity1));
            Assert.That(_result[1].OptimumVelocity, Is.EqualTo(_optimumVelocity2));
        }

    }
}
