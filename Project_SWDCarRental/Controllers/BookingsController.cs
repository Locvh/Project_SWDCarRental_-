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
    public class BookingsController : Controller  // gọi các service để thực hiện các nhiệm vụ tương ứng 
    {
        private readonly IBookingService _BookingService;


        public BookingsController(IBookingService BookingService)
        {
            _BookingService = BookingService;
        }
        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking([FromBody] Booking Booking)
        {
            return await _BookingService.AddBookingAsync(Booking);
        }
        [HttpGet]
        public async Task<ActionResult<List<Booking>>> GetAllBookings()
        {

            return await _BookingService.GetAllBookingsAsync();
        }


        [HttpGet("GetById")]
        public async Task<ActionResult<Booking>> GetBookingById(int id)
        {
            return await _BookingService.GetBookingByIdAsync(id);
        }

        [HttpGet("DeleteAllBookingById")]
        public async Task<ActionResult<Booking>> DeleteAllBookingById(int id)
        {
            return await _BookingService.DeleteAllBookingAsync(id);
        }
    }
}