namespace Students.Api.Models.Students
{
    using global::Students.Models;
    using System;
    using System.Linq.Expressions;

    public class StudentsDataResponseModel
    {
        public static Expression<Func<Student, StudentsDataResponseModel>> FromModel
        {
            get
            {
                return s => new StudentsDataResponseModel
                {
                    Id = s.Id.ToString(),
                    Name = s.Name,
                    Number = s.Number
                };
            }
        } 

        public string Id { get; set; }

        public string Name { get; set; }

        public long Number { get; set; }
    }
}