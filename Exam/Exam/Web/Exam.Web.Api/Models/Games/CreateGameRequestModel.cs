namespace Exam.Web.Api.Models.Games
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class CreateGameRequestModel
    {
        [Required]
        [MaxLength(GameConstants.MaxGameNameLenght)]
        public string Name
        {
            get; set;
        }

        public string Number
        {
            get;set;
        }

        public string UserId
        {
            get; set;
        }
    }
}