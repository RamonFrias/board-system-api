using System.ComponentModel.DataAnnotations;

namespace BoardSystem.DTOs.RequestsDTO
{
    public class UpdateCommentRequestDTO
    {
        [Required]
        [StringLength(400)]
        public string Content { get; set; }
    }
}
