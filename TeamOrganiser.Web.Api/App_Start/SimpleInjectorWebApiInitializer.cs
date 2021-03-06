using TeamOrganiser.Data.Repositories;
using TeamOrganiser.Data.Repositories.Factories;

[assembly: WebActivator.PostApplicationStartMethod(typeof(TeamOrganiser.Web.Api.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace TeamOrganiser.Web.Api.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<ITeamRepositoryFactory, TeamRepositoryFactory>(Lifestyle.Scoped);
            container.Register<ITeamRepository, TeamRepository>(Lifestyle.Scoped);

        }
    }
}