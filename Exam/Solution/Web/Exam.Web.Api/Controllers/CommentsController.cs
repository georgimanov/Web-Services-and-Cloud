namespace Exam.Web.Api.Controllers
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    using Models.Comments;
    using Services.Data.Contracts;
    using Infrastructure.Validation;
    using System;

    [Authorize]
    [RoutePrefix("api/comments")]
    public class CommentsController : ApiController
    {
        private ICommentsService comments;

        public CommentsController(ICommentsService comments)
        {
            this.comments = comments;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id, [FromUri]int skip = 0, [FromUri]int take = 10)
        {
            if (skip < 0 || take < 0)
            {
                return this.BadRequest("Cannot provide negative values!");
            }

            var comments = this.comments.GetByRealEstateId(id, skip, take)
                .ProjectTo<CommentResponseModel>()
                .ToList();

            return this.Ok(comments);
        }

        [HttpGet]
        [Route("byuser/{username}")]
        public IHttpActionResult GetByUser(string username, [FromUri]int skip = 0, [FromUri]int take = 10)
        {
            if (skip < 0 || take < 0)
            {
                return this.BadRequest("Cannot provide negative values!");
            }

            var comments = this.comments.GetByUsername(username, skip, take)
                .ProjectTo<CommentResponseModel>()
                .ToList();

            return this.Ok(comments);
        }

        [HttpPost]
        [ValidateModel]
        public IHttpActionResult Post(CommentRequestModel model)
        {
            var comment = this.comments
                .CreateComment(content: model.Content, realEstateId: model.RealEstateId, userId: this.User.Identity.GetUserId());

            var commentResult = this.comments
               .GetCommentDetails(comment.Id)
               .ProjectTo<CommentResponseModel>()
               .FirstOrDefault();

            var location = string.Format("api/comments/{0}", comment.Id);

            return this.Created(location, commentResult);
        }
    }
}