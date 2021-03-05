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

        //public async Task<List<Booking>> GetAllBookingsAsync()
        //{
        //    return await GetAll().ToListAsync();
        //}

        public async Task<List<Booking>> GetAllBookingsAsyncPage(Pagging pagging)
        {
            /*Giả sử chúng ta cần lấy kết quả cho trang thứ ba của trang web, đếm 20 là số kết quả chúng ta muốn . 
             Điều đó có nghĩa là chúng ta muốn bỏ qua (( 3 - 1) * 20 ) = 40 kết quả đầu tiên, sau đó lấy 20 kết quả tiếp theo và trả lại chúng cho người gọi.*/

            return await GetAll()
               .Skip((pagging.PageNumber - 1) * pagging.PageSize)
               .Take(pagging.PageSize)
               .ToListAsync();
        }
    }
}
