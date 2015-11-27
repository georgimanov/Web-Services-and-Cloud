namespace Exam.Services.Data.Contracts
{
    using System.Linq;
    using Exam.Data.Models;

    public interface IUsersService
    {
        IQueryable<User> GetUserDetails(string username);

        User RateUser(string userId, int value);

        IQueryable<User> GetUserDetailsById(string userId);
    }
}
