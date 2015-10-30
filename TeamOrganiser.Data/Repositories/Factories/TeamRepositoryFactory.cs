namespace TeamOrganiser.Data.Repositories.Factories
{
    public class TeamRepositoryFactory : ITeamRepositoryFactory
    {
        public ITeamRepository Create()
        {
            return new TeamRepository();
        }
    }
}