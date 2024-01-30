using System.ComponentModel.DataAnnotations;

namespace TaskStates.ViewModels
{
    public class TaskViewModel: CreateViewModel
    {
        [Required(ErrorMessage = "The State field is required.")]
        [Display(Name = "State")]
        public string State { get; set; }
    }
}
