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
    public class BookingDetailsController : Controller  // gọi các service để thực hiện các nhiệm vụ tương ứng 
    {
        private readonly IBookingDetailService _BookingDetailService;


        public BookingDetailsController(IBookingDetailService BookingDetailService)
        {
            _BookingDetailService = BookingDetailService;
        }
        [HttpPost]
        public async Task<ActionResult<BookingDetail>> CreateBookingDetail([FromBody] BookingDetail BookingDetail)
        {
            return await _BookingDetailService.AddBookingDetailAsync(BookingDetail);
        }
        [HttpGet]
        public async Task<ActionResult<List<BookingDetail>>> GetAllBookingDetails()
        {

            return await _BookingDetailService.GetAllBookingDetailsAsync();
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