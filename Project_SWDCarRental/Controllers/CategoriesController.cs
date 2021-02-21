using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_SWDCarRental.Models;
using UnitOfWorkPattern.Services.Servies;

namespace Project_SWDCarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller  // gọi các service để thực hiện các nhiệm vụ tương ứng 
    {
        private readonly ICategoryService _CategoryService;


        public CategoriesController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] Category Category)
        {
            return await _CategoryService.AddCategoryAsync(Category);
        }
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategorys()
        {

            return await _CategoryService.GetAllCategorysAsync();
        }


        [HttpGet("GetById")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            return await _CategoryService.GetCategoryByIdAsync(id);
        }

        [HttpPost("UpdateId")]
        public async Task<ActionResult<Category>> PostCategoryById(int id, [FromBody] Category Category)
        {
            return await _CategoryService.UpdateCategoryAsync(id, Category);
        }

        [HttpGet("DeleteAllCategoryById")]
        public async Task<ActionResult<Category>> DeleteAllCategoryById(int id)
        {
            return await _CategoryService.DeleteAllCategoryAsync(id);
        }
    }
}