using System.ComponentModel.DataAnnotations;

namespace BoardSystem.DTOs.RequestsDTO
{
    public class CreateCommentRequestDTO
    {
        [Required]
        [StringLength(400)]
        public string Content { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser no mínimo 1")]
        public int TaskId { get; set; }
    }
}
