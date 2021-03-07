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



        public async Task<List<Vehicle>> GetAllVehiclesAsyncPage(Pagging pagging)
        {
            return await GetAll()
               .Where(x => x.Status == true)
               .Skip((pagging.PageNumber - 1) * pagging.PageSize)
               .Take(pagging.PageSize)
               .ToListAsync();
        }

        public async Task<List<Vehicle>> GetAllVehiclesAsyncPageStatusFalse(Pagging pagging)
        {
            return await GetAll()
               .Where(x => x.Status == false)
               .Skip((pagging.PageNumber - 1) * pagging.PageSize)
               .Take(pagging.PageSize)             
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