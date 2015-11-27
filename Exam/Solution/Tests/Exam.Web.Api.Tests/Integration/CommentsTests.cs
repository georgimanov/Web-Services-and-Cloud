namespace Exam.Web.Api.Tests.Integration
{
    using System.Net;
    using System.Net.Http;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;

    [TestClass]
    public class CommentsTests
    {
        /*
        Integration tests – test that the route requested without authenticated user returns unauthorized status code.
        */

        public static IServerBuilder server;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            server = MyWebApi.Server().Starts<Startup>();
        }

        [TestMethod]
        public void CommentsShouldReturnUnauthorizedResponse()
        {
            server
                 .WithHttpRequestMessage(req => req
                    .WithMethod(HttpMethod.Get)
                    .WithRequestUri("api/comments/byuser/pesho?skip=0&take=10"))
                .ShouldReturnHttpResponseMessage()
                .WithStatusCode(HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public void CommentsShouldReturnUnauthorizedResponseWithoutSkipAndTake()
        {
            server
                 .WithHttpRequestMessage(req => req
                    .WithMethod(HttpMethod.Get)
                    .WithRequestUri("api/comments/byuser/pesho"))
                .ShouldReturnHttpResponseMessage()
                .WithStatusCode(HttpStatusCode.Unauthorized);
        }

        [ClassCleanup]
        public static void Clean()
        {
            MyWebApi.Server().Stops();
        }
    }
}
