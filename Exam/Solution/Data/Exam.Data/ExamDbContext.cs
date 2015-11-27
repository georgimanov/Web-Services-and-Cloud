namespace Exam.Data
{
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ExamDbContext : IdentityDbContext<User>, IExamDbContext
    {
        public ExamDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ExamDbContext Create()
        {
            return new ExamDbContext();
        }
    }
}
