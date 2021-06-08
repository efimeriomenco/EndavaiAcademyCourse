using Endava.iAcademy.Domain;

namespace Endava.iAcademy.Repository
{
    public static class RolesConstants
    {
        public static readonly Role Admin = new Role()
        {
            Id = 1,
            Name = "Admin",
        };

        public static readonly Role Customer = new Role()
        {
            Id = 2,
            Name = "Customer",
        };
    }
}