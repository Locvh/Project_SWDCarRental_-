using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkPattern.Repository.Models;

namespace UnitOfWorkPattern.Services.Servies
{
   public interface IBookingDetailService
    {
        //Task<List<BookingDetail>> GetAllBookingDetailsAsync();

        Task<List<BookingDetail>> GetAllBookingDetailsAsyncPage(Pagging pagging);

        Task<BookingDetail> GetBookingDetailByIdAsync(int id);

        Task<BookingDetail> AddBookingDetailAsync(BookingDetail newBookingDetail);
        Task<BookingDetail> UpdateBookingDetailAsync(int id, BookingDetail newBookingDetail);
        Task<BookingDetail> DeleteAllBookingDetailAsync(int id);
    }
}
