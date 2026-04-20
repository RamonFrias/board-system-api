using BoardSystem.Enums;
using System.ComponentModel.DataAnnotations;

namespace BoardSystem.DTOs.RequestsDTO
{
    public class UpdateTaskRequestDTO
    {
        [Required]
        [StringLength(60)]
        public string Title { get; set; }
        [Required]
        [StringLength(60)]
        public string Description { get; set; }
        public TasksStatus Status { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser no mínimo 1")]
        public int BoardId { get; set; }
    }
}
