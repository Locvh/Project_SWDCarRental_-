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
    public class VehiclesController : Controller  // gọi các service để thực hiện các nhiệm vụ tương ứng 
    {
        private readonly IVehicleService _VehicleService;


        public VehiclesController(IVehicleService VehicleService)
        {
            _VehicleService = VehicleService;
        }
        [HttpPost]
        public async Task<ActionResult<Vehicle>> CreateVehicle([FromBody] Vehicle Vehicle)
        {
            return await _VehicleService.AddVehicleAsync(Vehicle);
        }
        [HttpGet]
        public async Task<ActionResult<List<Vehicle>>> GetAllVehicles()
        {

            return await _VehicleService.GetAllVehiclesAsync();
        }

        [HttpGet("GetStatusFalse")]
        public async Task<ActionResult<List<Vehicle>>> GetAllVehiclesStatusFalseAsync()
        {

            return await _VehicleService.GetAllVehiclesStatusFalseAsync();
        }

        [HttpGet("GetPage")]
        public async Task<ActionResult<List<Vehicle>>> GetAllVehiclesPage([FromQuery] Pagging pagging)
        {

            return await _VehicleService.GetAllVehiclesAsyncPage(pagging);
        }
        [HttpGet("GetPageFalse")]
        public async Task<ActionResult<List<Vehicle>>> GetAllVehiclesAsyncPageStatusFalse([FromQuery] Pagging pagging)
        {

            return await _VehicleService.GetAllVehiclesAsyncPageStatusFalse(pagging);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Vehicle>> GetVehicleById(int id)
        {
            return await _VehicleService.GetVehicleByIdAsync(id);
        }


        [HttpGet("CheckDate")]
        public async Task<IEnumerable<Vehicle>> SearchByLikeName(int seat , DateTime checkIn,DateTime checkOut)
        {
            return await _VehicleService.Search(seat, checkIn,checkOut);
        }

        [HttpPost("UpdateId")]
        public async Task<ActionResult<Vehicle>> PostVehicleById(int id, [FromBody] Vehicle Vehicle)
        {
            return await _VehicleService.UpdateVehicleAsync(id, Vehicle);
        }

        [HttpGet("DeleteVehicleById")]
        public async Task<ActionResult<Vehicle>> DeleteVehicleById(int id)
        {
            return await _VehicleService.DeleteVehicleAsync(id);
        }

        [HttpGet("DeleteAllVehicleById")]
        public async Task<ActionResult<Vehicle>> DeleteAllVehicleById(int id)
        {
            return await _VehicleService.DeleteAllVehicleAsync(id);
        }
    }
}
