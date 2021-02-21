using Microsoft.EntityFrameworkCore;
using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkPattern.Repository.Repositories
{
  public  class GarageRepository : Repository<Garage>, IGarageRepository
    {
        CarRentalDBContext CarRentalContext;

        public GarageRepository(CarRentalDBContext CarRentalContext) : base(CarRentalContext)
        {
            this.CarRentalContext = CarRentalContext;
        }


        public async Task<Garage> GetGarageByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.GarageId == id);
        }

        public async Task<List<Garage>> GetAllGaragesAsync()
        {
            return await GetAll().ToListAsync();
        }


        public async Task<IEnumerable<Garage>> search(string address)
        {
            IQueryable<Garage> query = CarRentalContext.Garages;

            if (!string.IsNullOrEmpty(address))
            {
                query = query.Where(x => x.Address.ToLower().Contains(address.Trim().ToLower()));
            }
            return await query.ToListAsync();
        }
    }
}
