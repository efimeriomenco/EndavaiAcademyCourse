using System.ComponentModel.DataAnnotations;

namespace Endava.iAcademy.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email not specified")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
