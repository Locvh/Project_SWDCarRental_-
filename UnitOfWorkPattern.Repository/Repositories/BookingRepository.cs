using Microsoft.EntityFrameworkCore;
using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkPattern.Repository.Models;

namespace UnitOfWorkPattern.Repository.Repositories
{
   public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        CarRentalDBContext CarRentalContext;

        public BookingRepository(CarRentalDBContext CarRentalContext) : base(CarRentalContext)
        {
            this.CarRentalContext = CarRentalContext;
        }


        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.ResId == id);
        }


        public async Task<List<Booking>> GetAllBookingsAsyncPage(Pagging pagging)
        {

            return await GetAll()
               .Skip((pagging.PageNumber - 1) * pagging.PageSize)
               .Take(pagging.PageSize)
               .ToListAsync();
        }
    }
}
