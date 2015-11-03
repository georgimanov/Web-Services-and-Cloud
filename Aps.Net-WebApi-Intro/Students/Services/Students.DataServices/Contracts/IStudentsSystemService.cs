namespace Students.DataServices.Contracts
{
    using System;
    using System.Linq;

    using Common;
    using Models;

    public interface IStudentsSystemService
    {
        IQueryable<Student> All(int page = 1, int pageSize = GlobalConstants.DefaultPageSize);

        Guid Add(string name, long number);

        int Update(string name, long number);

        int Delete(string name);
    }
}
