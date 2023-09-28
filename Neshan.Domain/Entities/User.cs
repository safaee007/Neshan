using System.ComponentModel.DataAnnotations;

namespace Neshan.Domain.Entities
{
    public class User: BaseEntity
    {
        public Guid UserID { get; set; } // Contract: EntityName + ID
        [MaxLength(1000)]
        public string FirstName { get; set; }
        [MaxLength(1000)]
        public string LastName { get; set; }
        [MaxLength(4000)]
        public string Email { get; set; } // username
        public string Password { get; set; }
        public string Imagename { get; set; } = string.Empty;
        public byte Gender { get; set; }
        public bool Marriage { get; set; }
        public DateTime Birthday { get; set; } = DateTime.MinValue;
        public bool IsDisabled { get; set; } = false;
        public byte FailedLoginCount { get; set; } = 0;
        public DateTime? FailedLoginDate { get; set; }
        public DateTime? LastVisit { get; set; }
        public DateTime? ResetPasswordDate { get; set; }
    }
}
