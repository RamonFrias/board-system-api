using BoardSystem.Domains;
using System.ComponentModel.DataAnnotations;

namespace BoardSystem.DTOs.ResponsesDTO
{
    public class BoardResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public List<Tasks> Tasks { get; set; }
    }
}
