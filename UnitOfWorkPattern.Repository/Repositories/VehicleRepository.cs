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
   public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        CarRentalDBContext CarRentalContext;

        public VehicleRepository(CarRentalDBContext CarRentalContext) : base(CarRentalContext)
        {
            this.CarRentalContext = CarRentalContext;
        }


        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.VelNo == id);
        }

        public async Task<List<Vehicle>> GetAllVehiclesAsync()
        {
            return await GetAll().Where(x => x.Status == true).ToListAsync();
        }

        public async Task<List<Vehicle>> GetAllVehiclesStatusFalseAsync()
        {
            return await GetAll().Where(x => x.Status == false).ToListAsync();
        }


        public async Task<List<Vehicle>> GetAllVehiclesAsyncPage(Pagging pagging)
        {
            /*Giả sử chúng ta cần lấy kết quả cho trang thứ ba của trang web, đếm 20 là số kết quả chúng ta muốn . 
             Điều đó có nghĩa là chúng ta muốn bỏ qua (( 3 - 1) * 20 ) = 40 kết quả đầu tiên, sau đó lấy 20 kết quả tiếp theo và trả lại chúng cho người gọi.*/

            return await GetAll()
               .Skip((pagging.PageNumber - 1) * pagging.PageSize)
               .Take(pagging.PageSize)
               .Where(x => x.Status == true)
               .ToListAsync();
        }

        public async Task<List<Vehicle>> GetAllVehiclesAsyncPageStatusFalse(Pagging pagging)
        {
            /*Giả sử chúng ta cần lấy kết quả cho trang thứ ba của trang web, đếm 20 là số kết quả chúng ta muốn . 
             Điều đó có nghĩa là chúng ta muốn bỏ qua (( 3 - 1) * 20 ) = 40 kết quả đầu tiên, sau đó lấy 20 kết quả tiếp theo và trả lại chúng cho người gọi.*/

            return await GetAll()
               .Skip((pagging.PageNumber - 1) * pagging.PageSize)
               .Take(pagging.PageSize)
               .Where(x => x.Status == false)
               .ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> search(int seat , DateTime checkIn, DateTime checkOut)
        {
            IQueryable<Vehicle> query = CarRentalContext.Vehicles;

            if (seat!=0)
            {
                query = query.Where(x => x.Seat==seat && x.CheckInDate<=checkIn && x.CheckOutDate>=checkOut);
            }
            return await query.ToListAsync();
        }


    }

}