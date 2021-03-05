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

        //public async Task<List<BookingDetail>> GetAllBookingDetailsAsync()
        //{
        //    return await GetAll().ToListAsync();
        //}

        public async Task<List<BookingDetail>> GetAllBookingDetailsAsyncPage(Pagging pagging)
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
