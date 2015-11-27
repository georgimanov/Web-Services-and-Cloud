namespace Exam.Web.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Services.Data.Contracts;
    using AutoMapper.QueryableExtensions;

    using Models.Users;
    using Infrastructure.Validation;
    using Microsoft.AspNet.Identity;

    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private IUsersService users;

        public UsersController(IUsersService users)
        {
            this.users = users;
        }

        [HttpGet]
        [Route("{username}")]
        public IHttpActionResult Get(string username)
        {
            var user = this.users
                .GetUserDetails(username: username)
                .ProjectTo<UserResponseModel>()
                .FirstOrDefault();

            return this.Ok(user);
        }

        [Authorize]
        [HttpPost]
        [Route("rate")]
        [ValidateModel]
        public IHttpActionResult Post(RateRequestModel model)
        {
            var currentUser = this.User.Identity.GetUserId();
            if (currentUser == model.UserId)
            {
                return this.BadRequest("You are not allowed to vote for yourself!");
            }

            var user = this.users.RateUser(model.UserId, model.Value);

            var userRatingResult = this.users
               .GetUserDetailsById(userId: model.UserId)
               .ProjectTo<UserResponseModel>()
               .FirstOrDefault();

            var location = string.Format("api/users/{0}", user.UserName);

            return this.Created(location, userRatingResult);
        }
    }
}