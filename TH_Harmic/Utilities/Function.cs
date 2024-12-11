using TH_Harmic.Models;

namespace TH_Harmic.Utilities
{
    public class Function
    {
        public static string msg;
        public static TbAccount account;
        public static string  TitleSlugGenerationAlias (string title)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug (title);
        }
        public  string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public  bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
