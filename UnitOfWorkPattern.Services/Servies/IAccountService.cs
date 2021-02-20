﻿using Microsoft.AspNetCore.Mvc;
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
        Task<List<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(string id);

        //Task<IEnumerable<Account>> checkLogin(string username, string password);
        //Task<IEnumerable<Account>> Search(string fullname);
        Task<List<Account>> GetAllAccountsAsync1(Pagging pagging);
        Task<Account> AddAccountAsync(Account newAccount);
        ActionResult<Account> checkLogin(string username, string password);
        Task<Account> UpdateAccountAsync(string id, Account newAccount);
        Task<Account> DeleteAccountAsync(string id);
        Task<Account> DeleteAllAccountAsync(string id);
    }
}
