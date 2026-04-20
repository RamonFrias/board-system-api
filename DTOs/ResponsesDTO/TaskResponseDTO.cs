using BoardSystem.Domains;
using BoardSystem.Enums;
using System.ComponentModel.DataAnnotations;

namespace BoardSystem.DTOs.ResponsesDTO
{
    public class TaskResponseDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public TasksStatus Status { get; set; }
        public DateTime DueDate { get; set; }
        public int BoardId { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
