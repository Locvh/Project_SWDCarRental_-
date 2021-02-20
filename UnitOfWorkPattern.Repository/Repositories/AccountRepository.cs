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
            //var json = JsonConvert.SerializeObject(data);
            //Account c = new Account
            //{
            //    Role = json
            //};
            return Utils.success(data);
        }


        public async Task<Account> GetAccountByIdAsync(string id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.AccountId == id);
        }

        public async Task<List<Account>> GetAllAccountsAsync()
        {
            return await GetAll().ToListAsync();
        }



        public async Task<List<Account>> GetAllAccountsAsync1(Pagging pagging)
        {
            /*Giả sử chúng ta cần lấy kết quả cho trang thứ ba của trang web, đếm 20 là số kết quả chúng ta muốn . 
             Điều đó có nghĩa là chúng ta muốn bỏ qua (( 3 - 1) * 20 ) = 40 kết quả đầu tiên, sau đó lấy 20 kết quả tiếp theo và trả lại chúng cho người gọi.*/

            return await GetAll()
               .Skip((pagging.PageNumber - 1) * pagging.PageSize)
               .Take(pagging.PageSize).
               ToListAsync();
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
