namespace RememBeer.WebClient.Utils
{
    public static class StringExtensions
    {
        public static string Crop(this string text, int maxLength)
        {
            if (text == null)
            {
                return string.Empty;
            }

            if (text.Length < maxLength)
            {
                return text;
            }

            return text.Substring(0, maxLength);
        }

        public static string Truncate(this string text, int maxLength, string end = "...")
        {
            return text.Crop(maxLength) + end;
        }
    }
}
