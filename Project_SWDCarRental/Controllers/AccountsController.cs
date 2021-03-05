using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_SWDCarRental.Models;
using UnitOfWorkPattern.Repository.Models;
using UnitOfWorkPattern.Services.Servies;

namespace Project_SWDCarRental.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class accountsController : Controller  // gọi các service để thực hiện các nhiệm vụ tương ứng 
    {
        private readonly IAccountService _accountService;


        public accountsController(IAccountService AccountService)
        {
            _accountService = AccountService;
        }
        [HttpPost("CreateAccount")]
        public async Task<ActionResult<Account>> CreateAccount([FromBody] Account account)
        {
            return await _accountService.AddAccountAsync(account);
        }
        //[HttpGet]
        //public async Task<ActionResult<List<Account>>> GetAllAccounts()
        //{

        //    return await _accountService.GetAllAccountsAsync();
        //}

        //[HttpGet("GetStatusFalse")]
        //public async Task<ActionResult<List<Account>>> GetAllAccountsStatusFalseAsync()
        //{

        //    return await _accountService.GetAllAccountsStatusFalseAsync();
        //}

        [HttpGet("GetPage")]
        public async Task<ActionResult<List<Account>>> GetAllAccountsPage([FromQuery] Pagging pagging)
        {

            return await _accountService.GetAllAccountsAsyncPage(pagging);
        }
        [HttpGet("GetPageFalse")]
        public async Task<ActionResult<List<Account>>> GetAllAccountsAsyncPageStatusFalse([FromQuery] Pagging pagging)
        {

            return await _accountService.GetAllAccountsAsyncPageStatusFalse(pagging);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Account>> GetAccountById(string id)
        {
            return await _accountService.GetAccountByIdAsync(id);
        }

        [HttpGet("checkLogin")]
        public ActionResult<Account> CheckLogin(string username, string password)
        {
            return _accountService.checkLogin(username, password);
        }

        [HttpPost("UpdateId")]
        public async Task<ActionResult<Account>> PostAccountById(string id, [FromBody] Account account)
        {
            return await _accountService.UpdateAccountAsync(id, account);
        }

        [HttpGet("DeleteAccountById")]
        public async Task<ActionResult<Account>> DeleteAccountById(string id)
        {
            return await _accountService.DeleteAccountAsync(id);
        }

        [HttpGet("DeleteAllAccountById")]
        public async Task<ActionResult<Account>> DeleteAllAccountById(string id)
        {
            return await _accountService.DeleteAllAccountAsync(id);
        }
    }
}
