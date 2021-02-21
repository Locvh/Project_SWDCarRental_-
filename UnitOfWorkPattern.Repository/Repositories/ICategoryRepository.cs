using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkPattern.Repository.Repositories
{
   public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetCategoryByIdAsync(int id);

        Task<List<Category>> GetAllCategorysAsync();
       
    }
}
