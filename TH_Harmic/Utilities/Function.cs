namespace TH_Harmic.Utilities
{
    public class Function
    {
        public static string  TitleSlugGenerationAlias (string title)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug (title);
        }
    }
}
