using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkPattern.Repository.Repositories
{
   public interface IBookingDetailRepository : IRepository<BookingDetail>
    {
        Task<BookingDetail> GetBookingDetailByIdAsync(int id);

        Task<List<BookingDetail>> GetAllBookingDetailsAsync();

    }
}
