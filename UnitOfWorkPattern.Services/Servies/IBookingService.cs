using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkPattern.Repository.Models;

namespace UnitOfWorkPattern.Services.Servies
{
   public interface IBookingService
    {
        //Task<List<Booking>> GetAllBookingsAsync();

        Task<List<Booking>> GetAllBookingsAsyncPage(Pagging pagging);
        Task<Booking> GetBookingByIdAsync(int id);

        Task<Booking> AddBookingAsync(Booking newBooking);
        Task<Booking> DeleteAllBookingAsync(int id);
    }
}
