namespace Exam.Services.Data
{
    using Exam.Data.Models;
    using Exam.Data.Repositories;
    using Contracts;
    using System.Linq;
    using System;
    using Common.Constants;

    public class CommentsService : ICommentsService
    {
        private IRepository<Comment> comments;

        public CommentsService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public IQueryable<Comment> GetCommentDetails(int id)
        {
            return this.comments.All().Where(c => c.Id == id);
        }

        public IQueryable<Comment> GetByRealEstateId(
            int id,
            int skip = CommentsContants.DefaultSkip, 
            int take = CommentsContants.DefaultTake)
        {
            if (take > CommentsContants.MaxTake)
            {
                take = CommentsContants.MaxTake;
            }

            return this.comments
                .All()
                .Where(c => c.RealEstateId == id)
                .OrderBy(c => c.DateMade)
                .Skip(skip)
                .Take(take)
                .AsQueryable();
        }

        public IQueryable<Comment> GetByUsername(
            string username, 
            int skip = CommentsContants.DefaultSkip,
            int take = CommentsContants.DefaultTake)
        {
            if (take > CommentsContants.MaxTake)
            {
                take = CommentsContants.MaxTake;
            }

            return this.comments
                .All()
                .Where(c => c.UserName.UserName.Equals(username))
                .OrderBy(c => c.DateMade)
                .Skip(skip)
                .Take(take)
                .AsQueryable();
        }

        public Comment CreateComment(string content, int realEstateId, string userId)
        {
            var newComment = new Comment
            {
                DateMade = DateTime.UtcNow,
                Content = content,
                RealEstateId = realEstateId,
                UserId = userId
            };

            this.comments.Add(newComment);
            this.comments.SaveChanges();

            return newComment;
        }


        // TODO: Fix problem with opend DB reader
        private IQueryable<Comment> GetAllToBeReused(Func<Comment, bool> func, int skip = CommentsContants.DefaultSkip, int take = CommentsContants.DefaultTake)
        {
            if (take > CommentsContants.MaxTake)
            {
                take = CommentsContants.MaxTake;
            }

            return this.comments
                .All()
                .Where(func)
                .OrderBy(c => c.DateMade)
                .Skip(skip)
                .Take(take)
                .AsQueryable();
        }
    }
}
