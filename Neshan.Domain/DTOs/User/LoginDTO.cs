using System.ComponentModel.DataAnnotations;

namespace Neshan.Domain.DTOs.User
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Please Enter Email...")]
        [Display(Name = "ایمیل")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Password...")]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
