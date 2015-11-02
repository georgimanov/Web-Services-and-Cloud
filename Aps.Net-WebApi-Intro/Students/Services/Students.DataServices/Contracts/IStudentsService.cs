namespace Students.DataServices.Contracts
{
    using System;
    using System.Linq;

    using Common;
    using Models;

    public interface IStudentsService
    {
        IQueryable<Student> All(int page = 1, int pageSize = GlobalConstants.DefaultPageSize);

        Guid Add(string name, long number);
    }
}
