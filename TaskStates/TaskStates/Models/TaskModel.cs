using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace TaskStates.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Room { get; set; }
        public string Img { get; set; }
        public string State { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
