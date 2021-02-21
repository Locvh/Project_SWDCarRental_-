using Microsoft.EntityFrameworkCore;
using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkPattern.Repository.Repositories
{
   public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        CarRentalDBContext CarRentalContext;

        public CategoryRepository(CarRentalDBContext CarRentalContext) : base(CarRentalContext)
        {
            this.CarRentalContext = CarRentalContext;
        }


        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.CateId == id);
        }

        public async Task<List<Category>> GetAllCategorysAsync()
        {
            return await GetAll().ToListAsync();
        }

      
    }
}
