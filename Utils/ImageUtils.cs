namespace ariel_my_friend.Utils
{
    public static class ImageUtils
    {
        public static byte[]? ConvertFromIFormFile(IFormFile image)
        {
            try
            {
                using MemoryStream ms = new();
                image.CopyTo(ms);
                return ms.ToArray();
            }
            catch (Exception ex)
            {
                return null;

            }
        }
    }
}
