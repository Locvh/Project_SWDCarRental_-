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
   public class UserRepository : Repository<User>, IUserRepository
    {
        CarRentalDBContext CarRentalContext;

        public UserRepository(CarRentalDBContext CarRentalContext) : base(CarRentalContext)
        {
            this.CarRentalContext = CarRentalContext;
        }


        public async Task<User> GetUserByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await GetAll().Where(x => x.Status == true).ToListAsync();
        }

        public async Task<List<User>> GetAllUsersStatusFalseAsync()
        {
            return await GetAll().Where(x => x.Status == false).ToListAsync();
        }


        public async Task<List<User>> GetAllUsersAsyncPage(Pagging pagging)
        {
            /*Giả sử chúng ta cần lấy kết quả cho trang thứ ba của trang web, đếm 20 là số kết quả chúng ta muốn . 
             Điều đó có nghĩa là chúng ta muốn bỏ qua (( 3 - 1) * 20 ) = 40 kết quả đầu tiên, sau đó lấy 20 kết quả tiếp theo và trả lại chúng cho người gọi.*/

            return await GetAll()
               .Skip((pagging.PageNumber - 1) * pagging.PageSize)
               .Take(pagging.PageSize)
               .Where(x => x.Status == true)
               .ToListAsync();
        }

        public async Task<List<User>> GetAllUsersAsyncPageStatusFalse(Pagging pagging)
        {
            /*Giả sử chúng ta cần lấy kết quả cho trang thứ ba của trang web, đếm 20 là số kết quả chúng ta muốn . 
             Điều đó có nghĩa là chúng ta muốn bỏ qua (( 3 - 1) * 20 ) = 40 kết quả đầu tiên, sau đó lấy 20 kết quả tiếp theo và trả lại chúng cho người gọi.*/

            return await GetAll()
               .Skip((pagging.PageNumber - 1) * pagging.PageSize)
               .Take(pagging.PageSize)
               .Where(x => x.Status == false)
               .ToListAsync();
        }

        public async Task<IEnumerable<User>> search(string fullname)
        {
            IQueryable<User> query = CarRentalContext.Users;

            if (!string.IsNullOrEmpty(fullname))
            {
                query = query.Where(x => x.FullName.ToLower().Contains(fullname.Trim().ToLower()));
            }
            return await query.ToListAsync();
        }


    }

}
