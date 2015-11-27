namespace Exam.Web.Api.Models.Users
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class RateRequestModel 
    {
        [Required]
        public string UserId
        {
            get; set;
        }

        [Required]
        [Range(RateConstants.MinValue, RateConstants.MaxValue)]
        public int Value
        {
            get; set;
        }
    }
}