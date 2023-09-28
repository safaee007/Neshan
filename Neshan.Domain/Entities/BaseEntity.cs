using System.ComponentModel.DataAnnotations;

namespace Neshan.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
