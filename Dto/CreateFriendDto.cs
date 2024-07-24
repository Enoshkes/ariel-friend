using System.ComponentModel.DataAnnotations;

namespace ariel_my_friend.Dto
{
    public record CreateFriendDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; } = null;
    }
}
