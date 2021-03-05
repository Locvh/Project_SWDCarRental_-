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
    [Route("[controller]")]
    [ApiController]
    public class bookingDetailsController : Controller  // gọi các service để thực hiện các nhiệm vụ tương ứng 
    {
        private readonly IBookingDetailService _BookingDetailService;


        public bookingDetailsController(IBookingDetailService BookingDetailService)
        {
            _BookingDetailService = BookingDetailService;
        }
        [HttpPost("CreateBookingDetail")]
        public async Task<ActionResult<BookingDetail>> CreateBookingDetail([FromBody] BookingDetail BookingDetail)
        {
            return await _BookingDetailService.AddBookingDetailAsync(BookingDetail);
        }
        [HttpGet("GetBookingDetailPage")]
        public async Task<ActionResult<List<BookingDetail>>> GetAllBookingDetailsPage([FromQuery] Pagging pagging)
        {

            return await _BookingDetailService.GetAllBookingDetailsAsyncPage(pagging);
        }
        [HttpGet("GetById")]
        public async Task<ActionResult<BookingDetail>> GetBookingDetailById(int id)
        {
            return await _BookingDetailService.GetBookingDetailByIdAsync(id);
        }

        [HttpPost("UpdateId")]
        public async Task<ActionResult<BookingDetail>> PostBookingDetailById(int id, [FromBody] BookingDetail BookingDetail)
        {
            return await _BookingDetailService.UpdateBookingDetailAsync(id, BookingDetail);
        }

        [HttpGet("DeleteAllBookingDetailById")]
        public async Task<ActionResult<BookingDetail>> DeleteAllBookingDetailById(int id)
        {
            return await _BookingDetailService.DeleteAllBookingDetailAsync(id);
        }
    }
}