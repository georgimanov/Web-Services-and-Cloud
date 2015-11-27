using Exam.Data;
using Exam.Data.Models;
using Exam.Data.Repositories;

namespace Exam.Web.Wcf
{
    public abstract class BaseService
    {
        protected BaseService()
        {
            var dbContext = new ExamDbContext();
            this.Users = new EfGenericRepository<User>(dbContext);
        }

        protected IRepository<User> Users
        {
            get; set;
        }
    }
}