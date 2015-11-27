namespace Exam.Web.Api.Models.RealEstates
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Data.Models;

    public class CreateRealEstateRequestModel : IValidatableObject
    {
        [Required]
        [MinLength(RealEstateConstants.MinRealEstateTitleLenght)]
        [MaxLength(RealEstateConstants.MaxRealEstateTitleLenght)]
        public string Title { get;set; }

        [Required]
        [MinLength(RealEstateConstants.MinRealEstateDescriptionLenght)]
        [MaxLength(RealEstateConstants.MaxRealEstateDescriptionLenght)]
        public string Description { get; set; }

        [Required]
        [MaxLength(RealEstateConstants.MaxLenghtForUnspecifiedStrings)]
        public string Address { get; set; }

        [Required]
        [MaxLength(RealEstateConstants.MaxLenghtForUnspecifiedStrings)]
        public string Contact { get; set; }

        [Range(RealEstateConstants.RealEstateConstructionYearMinimum, RealEstateConstants.RealEstateConstructionYearMaximum)]
        public int ConstructionYear  { get; set; }

        public decimal? SellingPrice { get; set; }

        public decimal? RentingPrice { get; set; }

        public int RealEstateType { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.SellingPrice == null && this.RentingPrice == null)
            {
                yield return new ValidationResult("Real estate can be published only for renting, only for selling or for both, but not without any of the two options!");
            }
        }
    }
}