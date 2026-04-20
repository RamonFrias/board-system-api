using System.ComponentModel.DataAnnotations;

namespace BoardSystem.DTOs.RequestsDTO
{
    public class CreateBoardRequestDTO
    {
        [Required]
        [StringLength(60)]
        public string Title { get; set; }
        [StringLength(300)]
        public string? Description { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser no mínimo 1")]
        public int UserId { get; set; }
    }
}
