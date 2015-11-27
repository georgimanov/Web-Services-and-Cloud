
namespace Exam.Web.Api.Tests
{
    using Common.Constants;
    using Data.Repositories;
    using Data.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Setups;
    using MyTested.WebApi;
    using System.Web.Http;

    [TestClass]
    public class TestInit
    {
        [AssemblyInitialize]
        public static void Initialize(TestContext testContext)
        {
            NinjectConfig.DependenciesRegistration = kernel =>
            {
                kernel.Bind(typeof(IRepository<User>)).ToConstant(Repositories.GetUsersRepository());

                kernel.Bind(typeof(IRepository<RealEstate>)).ToConstant(Repositories.GetRealEstatesRepository());

                kernel.Bind(typeof(IRepository<Comment>)).ToConstant(Repositories.GetCommentsRepository());
            };

            AutoMapperConfig.RegisterMappings(Assemblies.WebApi);

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            MyWebApi.IsUsing(config);
        }
    }
}
