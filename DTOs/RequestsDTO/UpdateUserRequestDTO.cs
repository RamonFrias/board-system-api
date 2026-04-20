using System.ComponentModel.DataAnnotations;

namespace BoardSystem.DTOs.RequestsDTO
{
    public class UpdateUserRequestDTO
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z0-9]+@[a-z]+\.[a-z]{1,3}$")]
        public string Email { get; set; }
    }
}
