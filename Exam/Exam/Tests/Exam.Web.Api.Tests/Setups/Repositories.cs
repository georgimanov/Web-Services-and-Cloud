namespace Exam.Web.Api.Tests.Setups
{
    using System.Collections.Generic;
    using System.Linq;
    using Exam.Data.Models;
    using Exam.Data.Repositories;
    using Moq;

    public static class Repositories
    {
        public static IRepository<User> GetUsersRepository()
        {
            var repository = new Mock<IRepository<User>>();

            repository.Setup(r => r.All()).Returns(() =>
            {
                return new List<User>
                {
                    new User {Email = "pesho1@pesho.abv" }
                }
                .AsQueryable();
            });

            return repository.Object;
        }
    }
}
