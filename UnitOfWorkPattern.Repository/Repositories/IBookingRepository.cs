using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkPattern.Repository.Models;

namespace UnitOfWorkPattern.Repository.Repositories
{
   public interface IBookingRepository : IRepository<Booking>
    {
        Task<Booking> GetBookingByIdAsync(int id);

       // Task<List<Booking>> GetAllBookingsAsync();

        Task<List<Booking>> GetAllBookingsAsyncPage(Pagging pagging);
    }
}
