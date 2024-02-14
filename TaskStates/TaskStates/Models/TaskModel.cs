using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace TaskStates.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Title field is required.")]
        [Display(Name = "Title")]
        public string TaskName { get; set; }

        [Required(ErrorMessage = "The Room field is required.")]
        [Display(Name = "Room")]
        public string Room { get; set; }
        public string Img { get; set; }

        [Required(ErrorMessage = "The State field is required.")]
        [Display(Name = "State")]
        public string State { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
