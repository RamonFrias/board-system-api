using BoardSystem.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BoardSystem.Domains
{
    [Table("Tasks")]
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Title { get; set; }
        [StringLength(600)]
        public string? Description { get; set; }
        public TasksStatus Status { get; set; } = 0;
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser no mínimo 1")]
        public int BoardId { get; set; }
        public Board Board { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
