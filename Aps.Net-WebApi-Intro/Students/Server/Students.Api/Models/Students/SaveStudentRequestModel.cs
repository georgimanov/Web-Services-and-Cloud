namespace Students.Api.Models.Students
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class SaveStudentRequestModel
    {
        [Required]
        [MinLength(ValidationConstants.MinStudentName)]
        [MaxLength(ValidationConstants.MaxStudentName)]
        public string Name { get; set; }

        [Required]
        public long Number { get; set; }
    }
}