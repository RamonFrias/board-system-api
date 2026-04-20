using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BoardSystem.Domains
{
    [Table("Boards")]
    public class Board
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Title { get; set; }
        [StringLength(300)]
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser no mínimo 1")]
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Tasks> Tasks { get; set; }
    }
}
