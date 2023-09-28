using System.ComponentModel.DataAnnotations;

namespace Neshan.Domain.DTOs.User
{
    public class UserDTO :IValidatableObject
    {
        [Required(ErrorMessage = "نام خود را وارد نمایید")]
        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "نام خانوادگی خود را وارد نمایید")]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "ایمیل خود را وارد نمایید")]
        [Display(Name = "ایمیل(نام کاربری)")]
        [EmailAddress]
        public string Email { get; set; } // username

        [Required(ErrorMessage = "رمز عبور خود را وارد نمایید")]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(string.IsNullOrEmpty(FirstName))
                yield return new ValidationResult("نام خود را وارد نمایید");
        }

        public static implicit operator UserDTO(Neshan.Domain.Entities.User model)
        {
            return new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
            };
        }
    }
}
