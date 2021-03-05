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
    [Route("[controller]")]
    [ApiController]
    public class garagesController : Controller  // gọi các service để thực hiện các nhiệm vụ tương ứng 
    {
        private readonly IGarageService _GarageService;


        public garagesController(IGarageService GarageService)
        {
            _GarageService = GarageService;
        }
        [HttpPost("CreateGarage")]
        public async Task<ActionResult<Garage>> CreateGarage([FromBody] Garage Garage)
        {
            return await _GarageService.AddGarageAsync(Garage);
        }
        [HttpGet("GetGarage")]
        public async Task<ActionResult<List<Garage>>> GetAllGarages()
        {

            return await _GarageService.GetAllGaragesAsync();
        }


        [HttpGet("GetById")]
        public async Task<ActionResult<Garage>> GetGarageById(int id)
        {
            return await _GarageService.GetGarageByIdAsync(id);
        }


        [HttpGet("SearchByLikeAddress")]
        public async Task<IEnumerable<Garage>> SearchByLikeName(string address)
        {
            return await _GarageService.Search(address);
        }

        [HttpPost("UpdateId")]
        public async Task<ActionResult<Garage>> PostGarageById(int id, [FromBody] Garage Garage)
        {
            return await _GarageService.UpdateGarageAsync(id, Garage);
        }

        [HttpGet("DeleteAllGarageById")]
        public async Task<ActionResult<Garage>> DeleteAllGarageById(int id)
        {
            return await _GarageService.DeleteAllGarageAsync(id);
        }
    }
}
