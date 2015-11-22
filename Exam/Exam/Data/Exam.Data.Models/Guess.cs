namespace Exam.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Guess
    {
        public int Id
        {
            get; set;
        }

        [Required]
        [MinLength(Exam.Common.Constants.GameConstants.MaxGuessNumberLenght)]
        [MaxLength(Exam.Common.Constants.GameConstants.MinGuessNumberLenght)]
        public string Number
        {
            get;
            set;
        }

        public DateTime DateMade
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }
        
        public virtual User User
        {
            get; set;
        } 

        public int GameId
        {
            get;
            set;
        }

        public virtual Game Game
        {
            get; set;
        }
    }
}