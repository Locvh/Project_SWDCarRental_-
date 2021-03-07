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


        public async Task<List<User>> GetAllUsersAsyncPage(Pagging pagging)
        {
         
            return await GetAll()
               .Where(x => x.Status == true)
               .Skip((pagging.PageNumber - 1) * pagging.PageSize)
               .Take(pagging.PageSize) 
               .ToListAsync();
        }

        public async Task<List<User>> GetAllUsersAsyncPageStatusFalse(Pagging pagging)
        {
          
            return await GetAll()
               .Where(x => x.Status == false)
               .Skip((pagging.PageNumber - 1) * pagging.PageSize)
               .Take(pagging.PageSize)               
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
