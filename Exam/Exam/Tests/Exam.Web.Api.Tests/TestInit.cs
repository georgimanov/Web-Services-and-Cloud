
namespace Exam.Web.Api.Tests
{
    using Common.Constants;
    using Data.Repositories;
    using Data.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Setups;

    [TestClass]
    public class TestInit
    {
        [AssemblyInitialize]
        public static void Initialize(TestContext testContext)
        {
            NinjectConfig.DependenciesRegistration = kernel =>
            {
                kernel.Bind(typeof(IRepository<User>)).ToConstant(Repositories.GetUsersRepository());

                kernel.Bind(typeof(IRepository<Game>)).ToConstant(Repositories.GetGamesRepository());
            };

            AutoMapperConfig.RegisterMappings(Assemblies.WebApi);
        }
    }
}
