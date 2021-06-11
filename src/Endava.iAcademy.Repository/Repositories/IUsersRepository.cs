using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Endava.iAcademy.Domain;

namespace Endava.iAcademy.Repository.Repositories
{
    public interface IUsersRepository
    {
        bool DoesUserOwnTheCourse(int userId, int courseId);
        User CheckUserPassword(string password, string email);
        User GetUserByEmail(string email);
        User RegisterUser(User registeredUser);
        void PurchaseCourse(int userId, int courseId);
    }
}
