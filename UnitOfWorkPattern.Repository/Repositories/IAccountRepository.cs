using Microsoft.AspNetCore.Mvc;
using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkPattern.Repository.Models;

namespace UnitOfWorkPattern.Repository.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account> GetAccountByIdAsync(string id);

        //Task<IEnumerable<Account>> checkLogin(string username, string password);
        ActionResult<Account> checkLogin(string username, string password);

        Task<List<Account>> GetAllAccountsAsync();

        Task<List<Account>> GetAllAccountsAsync1(Pagging pagging);


        //Task<IEnumerable<Account>> search(string fullname);

    }
}
