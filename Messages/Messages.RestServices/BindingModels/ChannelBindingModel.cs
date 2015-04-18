using System.ComponentModel.DataAnnotations;

namespace Messages.RestServices.BindingModels
{
    public class ChannelBindingModel
    {

        [Required(ErrorMessage = "The name is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Name { get; set; }
    }
}