namespace Exam.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class RealEstate
    {
        private ICollection<Comment> comments;

        public RealEstate()
        {
            this.comments = new HashSet<Comment>();
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(RealEstateConstants.MinRealEstateTitleLenght)]
        [MaxLength(RealEstateConstants.MaxRealEstateTitleLenght)]
        public string Title { get; set; }

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

        public RealEstateType RealEstateType { get; set; }

        public DateTime DateCreated { get; set;}

        public decimal? SellingPrice { get; set; }

        public decimal? RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        [Range(RealEstateConstants.RealEstateConstructionYearMinimum, 
            RealEstateConstants.RealEstateConstructionYearMaximum,
            ErrorMessage = "Real estate construction year is minimum 1800")]
        public int? ConstructionYear { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
