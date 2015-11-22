namespace Exam.Web.Api.Models.Games
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Common.Constants;

    public class CreateGameRequestModel : IValidatableObject
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var digits = this
                .Number
                .Where(char.IsDigit)
                .Distinct()
                .ToList();

            if (digits.Count() != GameConstants.GuessNumberLength)
            {
                yield return new ValidationResult("Number's digits must be distinct!");
            }
        }
    }
}