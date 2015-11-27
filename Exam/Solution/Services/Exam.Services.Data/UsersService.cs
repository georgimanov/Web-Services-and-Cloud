namespace Exam.Services.Data
{
    using System.Linq;
    using Exam.Data.Models;
    using Exam.Data.Repositories;
    using Contracts;
    using System;

    public class UsersService : IUsersService
    {
        private IRepository<User> users;
        private IRepository<Rating> ratings;

        public UsersService(IRepository<User> users, IRepository<Rating> ratings)
        {
            this.users = users;
            this.ratings = ratings;
        }

        public IQueryable<User> GetUserDetails(string username)
        {
            return this.users.All().Where(u => u.UserName.Equals(username));
        }

        public IQueryable<User> GetUserDetailsById(string userId)
        {
            return this.users
                .All()
                .Where(u => u.Id == userId);
        }

        public User RateUser(string userId, int value)
        {
            this.ratings.Add(new Rating { UserId = userId, Value = value });

            this.ratings.SaveChanges();

            return this.users.All().FirstOrDefault(u => u.Id == userId);
        }
    }
}
