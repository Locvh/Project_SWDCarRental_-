using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkPattern.Repository.Models;

namespace UnitOfWorkPattern.Repository.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        CarRentalDBContext CarRentalContext;

        public AccountRepository(CarRentalDBContext CarRentalContext) : base(CarRentalContext)
        {
            this.CarRentalContext = CarRentalContext;
        }

        public ActionResult<Account> checkLogin(string username, string password)
        {
            object data = GetAll().Where(x => x.AccountName == username && x.Password == password).Select(x => x.Role);
            return Utils.success(data);
        }


        public async Task<Account> GetAccountByIdAsync(string id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.AccountId == id);
        }

        //public async Task<List<Account>> GetAllAccountsAsync()
        //{
        //    return await GetAll().Where(x => x.Status == true).ToListAsync();
        //}

        //public async Task<List<Account>> GetAllAccountsStatusFalseAsync()
        //{
        //    return await GetAll().Where(x => x.Status == false).ToListAsync();
        //}


        public async Task<List<Account>> GetAllAccountsAsyncPage(Pagging pagging)
        {            
            return await GetAll()
               .Where(x => x.Status == true)
               .Skip((pagging.PageNumber - 1) * pagging.PageSize)
               .Take(pagging.PageSize)               
               .ToListAsync();
        }

        public async Task<List<Account>> GetAllAccountsAsyncPageStatusFalse(Pagging pagging)
        {          
            return await GetAll()
               .Where(x => x.Status == false)
               .Skip((pagging.PageNumber - 1) * pagging.PageSize)
               .Take(pagging.PageSize)              
               .ToListAsync();
        }

        //public async Task<IEnumerable<Account>> search(string fullname)
        //{
        //    IQueryable<Account> query = CarRentalContext.Accounts;

        //    if (!string.IsNullOrEmpty(fullname))
        //    {
        //        query = query.Where(x => x.FullName.ToLower().Contains(fullname.Trim().ToLower()));
        //    }
        //    return await query.ToListAsync();
        //}


    }
}


