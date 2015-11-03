namespace Students.Data
{
    using Models;
    using System.Data.Entity;
    using Contracts;
    using System;

    public class StudentsDbContext : DbContext, IStudentsDbContext
    {
        public StudentsDbContext()
            : base("Students")
        {
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }

        public static StudentsDbContext Create()
        {
            return new StudentsDbContext();
        }
    }
}
