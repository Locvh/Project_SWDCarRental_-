using Microsoft.AspNetCore.Mvc;
using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkPattern.Repository.Models;
using UnitOfWorkPattern.Repository.Repositories;

namespace UnitOfWorkPattern.Services.Servies
{
    public class AccountService : IAccountService  // dùng để gọi các Repository lên và có thể làm các business logic ở trong đây
    {
        private readonly IAccountRepository _accountRepository;

        private readonly CarRentalDBContext _context;

        private IUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository accountRepository, CarRentalDBContext context, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public async Task<Account> AddAccountAsync(Account newAccount)
        {
            Account account = new Account
            {
                AccountId=newAccount.AccountId,
                AccountName=newAccount.AccountName,
                Role="user",
                Status=true,
                GoogleId=newAccount.GoogleId,
                Password=newAccount.Password

            };
           
            return await _accountRepository.AddAsync(account);
        }


        public ActionResult<Account> checkLogin(string username, string password)
        {

            return _accountRepository.checkLogin(username, password);
        }

        public async Task<Account> DeleteAccountAsync(string id)
        {
            var account = _unitOfWork.Account.GetByID(id);
            account.Status = false;
            return await _accountRepository.DeleteAsync(account);
        }

        public async Task<Account> DeleteAllAccountAsync(string id)
        {
            var account = _unitOfWork.Account.GetByID(id);
            return await _accountRepository.DeleteAllAsync(account);
        }

        public async Task<Account> GetAccountByIdAsync(string id)
        {
            return await _accountRepository.GetAccountByIdAsync(id);
        }

        public async Task<List<Account>> GetAllAccountsAsyncPage(Pagging pagging)
        {
            return await _accountRepository.GetAllAccountsAsyncPage(pagging);
            
        }

        public async Task<List<Account>> GetAllAccountsAsyncPageStatusFalse(Pagging pagging)
        {
            return await _accountRepository.GetAllAccountsAsyncPageStatusFalse(pagging);
        }

        public async Task<Account> UpdateAccountAsync(string id, Account newAccount)
        {
            var account = _unitOfWork.Account.GetByID(id);
            account.Password = newAccount.Password;
            return await _accountRepository.UpdateAsync(account);
        }
    }
}
