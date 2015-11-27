namespace Exam.Web.Api.Tests.Setups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exam.Data.Models;
    using Exam.Data.Repositories;
    using Moq;
    using MyTested.WebApi;

    public static class Repositories
    {
        public static IRepository<User> GetUsersRepository()
        {
            var repository = new Mock<IRepository<User>>();

            repository.Setup(r => r.All()).Returns(() =>
            {
                return new List<User>
                {
                    new User { UserName = "pesho", Email = "pesho1@pesho.abv" },
                    new User { UserName = "gosho", Email = "pesho1@pesho.abv" },
                    new User { UserName = "tosho", Email = "pesho1@pesho.abv" }
                }
                .AsQueryable();
            });

            return repository.Object;
        }

        public static IRepository<Comment> GetCommentsRepository()
        {
            var repository = new Mock<IRepository<Comment>>();

            repository.Setup(r => r.All()).Returns(() =>
            {
                return new List<Comment>
                {
                    new Comment {
                        Content = "Test content 1",
                        UserName = new User { UserName = "peshoTest" },
                        RealEstate = new RealEstate { Id = 1, Title = "Some title 1" },
                        DateMade = DateTime.Now.AddDays(1) },
                     new Comment {
                        Content = "Test content 2",
                        UserName = new User { UserName = "peshoTest" },
                        RealEstate = new RealEstate { Id = 1, Title = "Some title 2" },
                        DateMade = DateTime.Now.AddDays(2) },
                     new Comment {
                        Content = "Test content 3",
                        UserName = new User { UserName = "peshoTest" },
                        RealEstate = new RealEstate { Id = 1, Title = "Some title 3" },
                        DateMade = DateTime.Now.AddDays(3) },
                     new Comment {
                        Content = "Test content 4",
                        UserName = new User { UserName = "peshoTest" },
                        RealEstate = new RealEstate { Id = 1, Title = "Some title 4" },
                        DateMade = DateTime.Now.AddDays(4) },
                     new Comment {
                        Content = "Test content 5",
                        UserName = new User { UserName = "peshoTest" },
                        RealEstate = new RealEstate { Id = 1, Title = "Some title 5" },
                        DateMade = DateTime.Now.AddDays(5) },
                     new Comment {
                        Content = "Test content 6",
                        UserName = new User { UserName = "peshoTest" },
                        RealEstate = new RealEstate { Id = 1, Title = "Some title 6" },
                        DateMade = DateTime.Now.AddDays(6) },
                      new Comment {
                        Content = "Test content 7",
                        UserName = new User { UserName = "peshoTest" },
                        RealEstate = new RealEstate { Id = 1, Title = "Some title 7" },
                        DateMade = DateTime.Now.AddDays(7) },
                     new Comment {
                        Content = "Test content 8",
                        UserName = new User { UserName = "peshoTest" },
                        RealEstate = new RealEstate { Id = 1, Title = "Some title 8" },
                        DateMade = DateTime.Now.AddDays(8) },
                     new Comment {
                        Content = "Test content 9",
                        UserName = new User { UserName = "peshoTest" },
                        RealEstate = new RealEstate { Id = 1, Title = "Some title 9" },
                        DateMade = DateTime.Now.AddDays(9) },
                     new Comment {
                        Content = "Test content 10",
                        UserName = new User { UserName = "peshoTest" },
                        RealEstate = new RealEstate { Id = 1, Title = "Some title 10" },
                        DateMade = DateTime.Now.AddDays(10) },
                     new Comment {
                        Content = "Test content 11",
                        UserName = new User { UserName = "peshoTest" },
                        RealEstate = new RealEstate { Id = 1, Title = "Some title 11" },
                        DateMade = DateTime.Now.AddDays(11) },
                     new Comment {
                        Content = "Test content 12",
                        UserName = new User { UserName = "peshoTest" },
                        RealEstate = new RealEstate { Id = 1, Title = "Some title 12" },
                        DateMade = DateTime.Now.AddDays(12) },
                }
                .AsQueryable();
            });

            return repository.Object;
        }

        public static IRepository<RealEstate> GetRealEstatesRepository()
        {
            var repository = new Mock<IRepository<RealEstate>>();

            repository.Setup(r => r.All()).Returns(() =>
            {
                return new List<RealEstate>
                {
                    new RealEstate { Title = "Test Title" }
                }
                .AsQueryable();
            });

            return repository.Object;
        }
    }
}
