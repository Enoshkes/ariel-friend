namespace ariel_my_friend.Models
{
    public class ImageModel
    {
        public int Id { get; set; }

        public byte[] Data { get; set; }

        public int FriendId { get; set; }

        public FriendModel Friend { get; set; }
    }
}