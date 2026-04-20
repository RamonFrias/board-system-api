using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BoardSystem.Domains
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(400)]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public int TaskId { get; set; }
        public Tasks Task { get; set; }
    }
}
