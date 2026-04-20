using System.ComponentModel.DataAnnotations;

namespace BoardSystem.DTOs.RequestsDTO
{
    public class UpdateBoardRequestDTO
    {
        [Required]
        [StringLength(60)]
        public string Title { get; set; }
        [StringLength(300)]
        public string? Description { get; set; }
    }
}
