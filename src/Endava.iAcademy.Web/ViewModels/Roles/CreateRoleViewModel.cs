using System.ComponentModel.DataAnnotations;

namespace Endava.iAcademy.Web.ViewModels.Roles
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
