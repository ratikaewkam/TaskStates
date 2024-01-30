using System.ComponentModel.DataAnnotations;

namespace TaskStates.ViewModels
{
    public class CreateViewModel
    {
        [Required(ErrorMessage = "The Title field is required.")]
        [Display(Name = "Title")]
        public string TaskName { get; set; }

        [Required(ErrorMessage = "The Room field is required.")]
        [Display(Name = "Room")]
        public string Room { get; set; }

        [Required(ErrorMessage = "The Image field is required.")]
        [Display(Name = "Image")]
        public IFormFile Img { get; set; }
    }
}
