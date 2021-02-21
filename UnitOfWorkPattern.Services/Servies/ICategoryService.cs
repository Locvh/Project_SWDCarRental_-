using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkPattern.Services.Servies
{
   public interface ICategoryService
    {
        Task<List<Category>> GetAllCategorysAsync();

        Task<Category> GetCategoryByIdAsync(int id);

        Task<Category> AddCategoryAsync(Category newCategory);
        Task<Category> UpdateCategoryAsync(int id, Category newCategory);
        Task<Category> DeleteAllCategoryAsync(int id);
    }
}
