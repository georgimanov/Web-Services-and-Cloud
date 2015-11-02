namespace Students.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Constants;

    public class Course
    {
        private ICollection<Student> students;

        private ICollection<Homework> homeworks;

        public Course()
        {
            this.Id = Guid.NewGuid();
            this.Students = new HashSet<Student>();
            this.Homeworks = new HashSet<Homework>();
        }

        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinCourseName)]
        [MaxLength(ValidationConstants.MaxCourseName)]
        public string Name { get; set; }


        [Required]
        [MinLength(ValidationConstants.MinCourseDescriptionLenght)]
        [MaxLength(ValidationConstants.MaxCourseDescriptionLenght)]
        public string Description { get; set; }

        [Required]
        public string Materials { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value;}
        }

        public ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value;}
        }
    }
}
