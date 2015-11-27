namespace Exam.Web.Api.Tests.Controllers
{
    using System.Collections.Generic;
    using Api.Controllers;
    using Models.RealEstates;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    using Setups;
    using Common.Constants;
    using Models.Comments;
    using System;

    [TestClass]
    public class CommentsControllerTests
    {
        private IControllerBuilder<CommentsController> controller;

        [TestInitialize]
        public void Init()
        {
            this.controller = MyWebApi
                .Controller<CommentsController>()
                .WithResolvedDependencies(Services.GetCommentsService());
        }

        /*	Unit tests – test that the action behind this route has appropriate action filters and that with its default skip and take parameters it returns correct response with correct number of elements. */

        [TestMethod]
        public void GetShouldReturnZeroComemnts()
        {
            controller
                .Calling(c => c.GetByUser("someRandomUser", 0, 1))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<CommentResponseModel>>()
                .Passing(model =>
                {
                    Assert.AreEqual(0, model.Count);
                });
        }

        [TestMethod]
        public void GetShouldReturnOneComment()
        {
            controller
                .Calling(c => c.GetByUser("peshoTest", 0, 1))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<CommentResponseModel>>()
                .Passing(model =>
                {
                    Assert.AreEqual(1, model.Count);
                });
        }

        [TestMethod]
        public void GetShouldReturnZeroBeacauseOfBigSkip()
        {
            controller
                .Calling(c => c.GetByUser("peshoTest", 10000, 1))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<CommentResponseModel>>()
                .Passing(model =>
                {
                    Assert.AreEqual(0, model.Count);
                });
        }

        [TestMethod]
        public void GetShouldReturnExactly10()
        {
            controller
                .Calling(c => c.GetByUser("peshoTest", 0, 10))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<CommentResponseModel>>()
                .Passing(model =>
                {
                    Assert.AreEqual(10, model.Count);
                });
        }

        [TestMethod]
        public void GetShouldReturnExactly10InAscendingOrder()
        {
            controller
                .Calling(c => c.GetByUser("peshoTest", 0, 10))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<CommentResponseModel>>()
                .Passing(model =>
                {
                    Assert.AreEqual(10, model.Count);

                    var current = model[0].CreatedOn;
                    for (int i = 1; i < model.Count; i++)
                    {
                        Assert.IsTrue(DateTime.Compare(model[i].CreatedOn, current) > 0);
                        current = model[i].CreatedOn;
                    }
                });
        }

        [TestMethod]
        public void GetShouldReturnExactly2Comments()
        {
            controller
                .Calling(c => c.GetByUser("peshoTest", 10, 10))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<CommentResponseModel>>()
                .Passing(model =>
                {
                    Assert.AreEqual(2, model.Count);
                });
        }
    }
}
