namespace Students.Models
{
    using Common.Constants;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        public Homework()
        {
            this.Id = Guid.NewGuid();
        }


        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinHomeworkContentLenght)]
        [MaxLength(ValidationConstants.MaxHomeworkContentLenght)]
        public string Content { get; set; }

        [Required]
        public DateTime TimeSentFrom { get; set; }

        public DateTime? TimeSentTo { get; set; }

        public string CourseId { get; set;}

        public virtual Course Course { get; set; }

        public string StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
