namespace Exam.Web.Api.Tests.Integration
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using Models.Games;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;

    [TestClass]
    public class GamesTests
    {
        public static IServerBuilder server;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            server = MyWebApi.Server().Starts<Startup>();
        }

        [TestMethod]
        public void GamesShouldReturnCorrectResponse()
        {
           MyWebApi.Server().Working<Startup>()
                .WithHttpRequestMessage(req =>req
                    .WithMethod(HttpMethod.Get)
                    .WithRequestUri("/api/games"))
                .ShouldReturnHttpResponseMessage()
                .WithStatusCode(HttpStatusCode.OK)
                .WithResponseModelOfType<List<PublicGameResponseModel>>()
                .Passing(model =>
                {
                    Assert.AreEqual(1, model.Count);
                });
        }

        [ClassCleanup]
        public static void Clean()
        {
            MyWebApi.Server().Stops();
        }
    }
}
