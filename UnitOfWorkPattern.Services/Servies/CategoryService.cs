using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkPattern.Repository.Repositories;

namespace UnitOfWorkPattern.Services.Servies
{
   public class CategoryService : ICategoryService  // dùng để gọi các Repository lên và có thể làm các business logic ở trong đây
    {
        private readonly ICategoryRepository _CategoryRepository;

        private readonly CarRentalDBContext _context;

        private IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository CategoryRepository, CarRentalDBContext context, IUnitOfWork unitOfWork)
        {
            _CategoryRepository = CategoryRepository;
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public async Task<Category> AddCategoryAsync(Category newCategory)
        {
            Category Category = new Category
            {
                Colour = newCategory.Colour,
                Manufacture = newCategory.Manufacture,
                Model = newCategory.Model

            };
            return await _CategoryRepository.AddAsync(Category);
        }


        public async Task<Category> DeleteAllCategoryAsync(int id)
        {
            var Category = _unitOfWork.Category.GetByID(id);
            return await _CategoryRepository.DeleteAllAsync(Category);
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _CategoryRepository.GetCategoryByIdAsync(id);
        }

        public async Task<List<Category>> GetAllCategorysAsync()
        {
            return await _CategoryRepository.GetAllCategorysAsync();
        }


        public async Task<Category> UpdateCategoryAsync(int id, Category newCategory)
        {
            var Category = _unitOfWork.Category.GetByID(id);
            Category.Colour = newCategory.Colour;
            Category.Manufacture = newCategory.Manufacture;
            Category.Model = newCategory.Model;
            return await _CategoryRepository.UpdateAsync(Category);
        }


    }
}