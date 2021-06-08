using System.ComponentModel.DataAnnotations;

namespace Endava.iAcademy.Web.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email not specified")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwod is incorrect")]
        public string ConfirmPassword { get; set; }
    }
}
