namespace Students.DataServices
{
    using System;
    using System.Linq;

    using Common;
    using Contracts;
    using Data.Contracts;
    using Models;

    public class StudentsSystemService : IStudentsSystemService
    {
        private readonly IRepository<Student> students;

        public StudentsSystemService(IRepository<Student> studentsRepo)
        {
            this.students = studentsRepo;
        }

        public Guid Add(string name, long number)
        {
            var newStudent = new Student()
            {
                Name = name,
                Number = number
            };

            this.students.Add(newStudent);
            this.students.SaveChanges();

            return newStudent.Id;
        }

        public IQueryable<Student> All(int page = 1, int pageSize = GlobalConstants.DefaultPageSize)
        {
            return this.students
                .All()
                .OrderBy(s => s.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public int Update(string name, long number)
        {
            throw new NotImplementedException();
        }

        public int Delete(string name)
        {
            throw new NotImplementedException();
        }
    }
}
