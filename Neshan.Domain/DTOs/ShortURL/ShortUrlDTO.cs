namespace Neshan.Domain.DTOs.ShortURL
{
    public class ShortUrlDTO
    {
        public int ShortUrlID { get; set; }
        public Uri OriginalURL { get; set; }
        public Uri ShortURL { get; set; }
        public string UrlKey { get; set; }
        public Guid UserID { get; set; }
        public int? VisitCount { get; set; }
        public long CreateDate { get; set; }// client
        public string CreateDate2 { get; set; }// server
    }
}
