using System.ComponentModel.DataAnnotations;

namespace Application08.Services
{
    public class TodoTask
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Task title is required")]
        [StringLength(100, ErrorMessage = "Task title cannot exceed 100 characters")]
        public string Title { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
