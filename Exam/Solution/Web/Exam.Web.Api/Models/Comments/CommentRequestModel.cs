namespace Exam.Web.Api.Models.Comments
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class CommentRequestModel
    {
        [Required]
        [MinLength(CommentsContants.MinContentLenght)]
        [MaxLength(CommentsContants.MaxContentLenght)]
        public string Content
        {
            get; set;
        }

        public int RealEstateId
        {
            get; set;
        }
    }
}