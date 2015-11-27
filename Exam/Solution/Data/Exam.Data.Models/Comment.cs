namespace Exam.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(CommentsContants.MinContentLenght)]
        [MaxLength(CommentsContants.MaxContentLenght)]
        public string Content { get; set; }

        public DateTime DateMade { get; set; }

        public string UserId { get; set; }
        
        public virtual User UserName { get; set; } 

        public int RealEstateId { get; set; }

        public virtual RealEstate RealEstate { get; set; }
    }
}