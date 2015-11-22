namespace Exam.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Game
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required]
        [MaxLength(GameConstants.MaxGameNameLenght)]
        public string Name
        {
            get; set;
        }

        public DateTime DateCreated
        {
            get; set;
        }

        public string BlueUserId
        {
            get; set;
        }

        public virtual User BlueUser
        {
            get; set;
        }

        public string RedUserId
        {
            get; set;
        }

        public virtual User RedUser
        {
            get; set;
        }
    }
}
