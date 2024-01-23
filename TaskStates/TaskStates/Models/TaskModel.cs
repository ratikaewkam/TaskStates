using System.ComponentModel.DataAnnotations;

namespace TaskStates.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Room { get; set; }
        public string Img { get; set; }
    }
}
