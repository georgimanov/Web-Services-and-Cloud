namespace Exam.Web.Api.Models.Games
{
    using System.ComponentModel.DataAnnotations;

    public class CreateGameRequestModel
    {
        [Required]
        [MaxLength(100)]
        public string Name
        {
            get; set;
        }

        public string Number
        {
            get;set;
        }
    }
}