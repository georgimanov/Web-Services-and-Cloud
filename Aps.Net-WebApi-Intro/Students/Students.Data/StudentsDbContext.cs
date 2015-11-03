namespace Students.Data
{
    using Models;
    using System.Data.Entity;
    using Contracts;

    public class StudentsSystemDbContext : DbContext, IStudentsSystemDbContext
    {
        public StudentsSystemDbContext()
            : base("Students")
        {
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }

        public static StudentsSystemDbContext Create()
        {
            return new StudentsSystemDbContext();
        }
    }
}
