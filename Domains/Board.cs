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
        [Required]
        [StringLength(300)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Tasks> Tasks { get; set; }
    }
}
