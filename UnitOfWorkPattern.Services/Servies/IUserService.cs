using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkPattern.Repository.Models;

namespace UnitOfWorkPattern.Services.Servies
{
   public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();

        Task<List<User>> GetAllUsersStatusFalseAsync();
        Task<User> GetUserByIdAsync(int id);

        Task<IEnumerable<User>> Search(string fullname);
        Task<List<User>> GetAllUsersAsyncPage(Pagging pagging);
        Task<List<User>> GetAllUsersAsyncPageStatusFalse(Pagging pagging);

        Task<User> AddUserAsync(User newUser);
        Task<User> UpdateUserAsync(int id, User newUser);
        Task<User> DeleteUserAsync(int id);
        Task<User> DeleteAllUserAsync(int id);
    }
}
