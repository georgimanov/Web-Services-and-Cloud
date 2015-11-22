namespace Exam.Web.Api.Tests.Controllers
{
    using System.Collections.Generic;
    using Api.Controllers;
    using Models.Games;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using Setups;

    [TestClass]
    public class GamesControllerTests
    {
        private IControllerBuilder<GamesController> controller;

        [TestInitialize]
        public void Init()
        {
            this.controller = MyWebApi
                .Controller<GamesController>()
                .WithResolvedDependencies(Services.GetGamesService());
        }

        [TestMethod]
        public void GetShouldReturnOK()
        {
            controller
                 .Calling(c => c.Get(1))
                 .ShouldReturn()
                 .Ok()
                 .WithResponseModelOfType<List<PublicGameResponseModel>>()
                 .Passing(model =>
                 {
                     Assert.AreEqual(1, model.Count);
                 });
        }
    }
}
