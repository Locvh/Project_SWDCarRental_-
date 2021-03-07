using Microsoft.AspNetCore.Mvc;
using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkPattern.Repository.Models;

namespace UnitOfWorkPattern.Services.Servies
{
    public interface IAccountService
    {
        Task<Account> GetAccountByIdAsync(string id);
        Task<List<Account>> GetAllAccountsAsyncPage(Pagging pagging);
        Task<List<Account>> GetAllAccountsAsyncPageStatusFalse(Pagging pagging);
        Task<Account> AddAccountAsync(Account newAccount);
        ActionResult<Account> checkLogin(string username, string password);
        Task<Account> UpdateAccountAsync(string id, Account newAccount);
        Task<Account> DeleteAccountAsync(string id);
        Task<Account> DeleteAllAccountAsync(string id);
    }
}
