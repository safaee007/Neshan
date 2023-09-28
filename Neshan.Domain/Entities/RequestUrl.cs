namespace Neshan.Domain.Entities
{
    public class RequestUrl : BaseEntity
    {
        public int ShortUrlID { get; set; }
        public Guid UserID { get; set; }
        public ShortUrl ShortUrl { get; set; }
    }
}
