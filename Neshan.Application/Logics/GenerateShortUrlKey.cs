namespace Neshan.Application.Logics
{
    public static class GenerateShortUrlKey
    {
        public static string Generate()
        {
            //return new Random().Next(0, 9999).ToString();
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 7);
        }
    }
}
