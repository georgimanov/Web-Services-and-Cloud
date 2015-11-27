namespace Exam.Services.Data.Contracts
{
    using System.Linq;
    using Exam.Data.Models;

    public interface ICommentsService
    {
        IQueryable<Comment> GetByUsername(string username, int skip = 0, int take = 0);

        IQueryable<Comment> GetByRealEstateId(int id, int skip = 0, int take = 0);

        Comment CreateComment(string content, int realEstateId, string userId);

        IQueryable<Comment> GetCommentDetails(int id);
    }
}
