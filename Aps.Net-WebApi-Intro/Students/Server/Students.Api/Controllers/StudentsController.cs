﻿namespace Students.Api.Controllers
{
    using Models.Students;
    using System.Linq;
    using System.Web.Http;
    using DataServices.Contracts;
    using Students.Models;
    using Data.Contracts;

    public class StudentsController : ApiController
    {
        private readonly IStudentsService students;

        public StudentsController(IRepository<Student> studentsRepo)
        {
            this.students = studentsRepo;
        }

        public IHttpActionResult Get()
        {
            var result = this.students
                .All()
                .Select(StudentsDataResponseModel.FromModel)
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return this.BadRequest("Student cannot be null or empty!");
            }

            var result = this.students
                .All()
                .Where(s => s.Name == name)
                .OrderByDescending(s => s.Number)
                .Select(StudentsDataResponseModel.FromModel)
                .FirstOrDefault();

            if(result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        public IHttpActionResult Post(SaveStudentRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var savedStudentId = this.students.Add(model.Name, model.Number);

            return this.Ok(savedStudentId);
        }
    }
}