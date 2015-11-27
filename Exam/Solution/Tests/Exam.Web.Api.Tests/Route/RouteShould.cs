namespace Exam.Web.Api.Tests.Route
{
    using Api.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;
    /*
    – test that the route is resolved to the correct controller, action and route values for the following situations: with default skip and take, with provided custom skip, with provided custom take, with provided custom skip and custom take. Additionally, test that the route does not have valid model state, if you do not provide the username.
    */

    [TestClass]
    public class RouteShould
    {
        [TestMethod]
        public void TestGetCommentsShouldMapCorrectlyWithProvidedCustomSkipAndTake()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/comments/ByUser/pesho?skip=1&take=4")
                .To<CommentsController>(c => c.GetByUser("pesho", 1, 4));
        }

        [TestMethod]
        public void TestGetCommentsShouldMapCorrectlyWithDefaultSkip()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/comments/ByUser/pesho")
                .To<CommentsController>(c => c.GetByUser("pesho", 0, 10));
        }

        [TestMethod]
        public void TestGetCommentsWithoutUsernameShooulNotHaveValidModelState()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/comments/ByUser")
                .ToInvalidModelState();
        }
    }
}
