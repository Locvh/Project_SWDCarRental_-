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
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller  // gọi các service để thực hiện các nhiệm vụ tương ứng 
    {
        private readonly IUserService _UserService;


        public UsersController(IUserService UserService)
        {
            _UserService = UserService;
        }
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User User)
        {
            return await _UserService.AddUserAsync(User);
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {

            return await _UserService.GetAllUsersAsync();
        }

        [HttpGet("GetStatusFalse")]
        public async Task<ActionResult<List<User>>> GetAllUsersStatusFalseAsync()
        {

            return await _UserService.GetAllUsersStatusFalseAsync();
        }

        [HttpGet("GetPage")]
        public async Task<ActionResult<List<User>>> GetAllUsersPage([FromQuery] Pagging pagging)
        {

            return await _UserService.GetAllUsersAsyncPage(pagging);
        }
        [HttpGet("GetPageFalse")]
        public async Task<ActionResult<List<User>>> GetAllUsersAsyncPageStatusFalse([FromQuery] Pagging pagging)
        {

            return await _UserService.GetAllUsersAsyncPageStatusFalse(pagging);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            return await _UserService.GetUserByIdAsync(id);
        }


        [HttpGet("SearchByLikeName")]
        public async Task<IEnumerable<User>> SearchByLikeName(string fullname)
        {
            return await _UserService.Search(fullname);
        }

        [HttpPost("UpdateId")]
        public async Task<ActionResult<User>> PostUserById(int id, [FromBody] User User)
        {
            return await _UserService.UpdateUserAsync(id, User);
        }

        [HttpGet("DeleteUserById")]
        public async Task<ActionResult<User>> DeleteUserById(int id)
        {
            return await _UserService.DeleteUserAsync(id);
        }

        [HttpGet("DeleteAllUserById")]
        public async Task<ActionResult<User>> DeleteAllUserById(int id)
        {
            return await _UserService.DeleteAllUserAsync(id);
        }
    }
}
