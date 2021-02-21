using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkPattern.Repository.Models;

namespace UnitOfWorkPattern.Repository.Repositories
{
   public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByIdAsync(int id);


        Task<List<User>> GetAllUsersAsync();

        Task<List<User>> GetAllUsersStatusFalseAsync();
        Task<List<User>> GetAllUsersAsyncPage(Pagging pagging);

        Task<List<User>> GetAllUsersAsyncPageStatusFalse(Pagging pagging);

        Task<IEnumerable<User>> search(string fullname);

    }
}
