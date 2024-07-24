using System.ComponentModel.DataAnnotations;

namespace ariel_my_friend.Models
{
    public class FriendModel
    {
        // Ariel: no need for key, the framework does it for you
        public int Id { get; set; }
        
        // Ariel: annotations for schema building
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength (50, MinimumLength = 3)]
        public required string LastName { get; set; }

        public List<ImageModel> Images { get; set; } = [];
    }
}
