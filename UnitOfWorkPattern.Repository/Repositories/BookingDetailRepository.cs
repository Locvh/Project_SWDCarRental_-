using Microsoft.EntityFrameworkCore;
using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkPattern.Repository.Repositories
{
  public class BookingDetailRepository : Repository<BookingDetail>, IBookingDetailRepository
    {
        CarRentalDBContext CarRentalContext;

        public BookingDetailRepository(CarRentalDBContext CarRentalContext) : base(CarRentalContext)
        {
            this.CarRentalContext = CarRentalContext;
        }


        public async Task<BookingDetail> GetBookingDetailByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<BookingDetail>> GetAllBookingDetailsAsync()
        {
            return await GetAll().ToListAsync();
        }


    }
}
