using System.ComponentModel.DataAnnotations;

namespace Neshan.Domain.Entities
{
    public class ShortUrl : BaseEntity
    {
        public Uri OriginalURL { get; set; }
        public Uri ShortURL { get; set; }
        [MaxLength(100)]
        public string UrlKey { get; set; }
        public Guid UserID { get; set; }= Guid.Empty;
        public DateTime LastVisit { get; set; }
        public ICollection<RequestUrl> RequestUrls { get; set; }
    }
}
