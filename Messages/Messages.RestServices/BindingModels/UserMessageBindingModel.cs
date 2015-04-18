using System.ComponentModel.DataAnnotations;

namespace Messages.RestServices.BindingModels
{
    public class UserMessageBindingModel
    {
        [Required]
        public string Recepient { get; set; }

        [Required]
        public string Text { get; set; }
    }
}