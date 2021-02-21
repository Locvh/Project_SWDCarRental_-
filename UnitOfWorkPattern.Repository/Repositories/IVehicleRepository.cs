using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkPattern.Repository.Models;

namespace UnitOfWorkPattern.Repository.Repositories
{
   public interface IVehicleRepository : IRepository<Vehicle>
    {
        Task<Vehicle> GetVehicleByIdAsync(int id);


        Task<List<Vehicle>> GetAllVehiclesAsync();

        Task<List<Vehicle>> GetAllVehiclesStatusFalseAsync();
        Task<List<Vehicle>> GetAllVehiclesAsyncPage(Pagging pagging);

        Task<List<Vehicle>> GetAllVehiclesAsyncPageStatusFalse(Pagging pagging);

        Task<IEnumerable<Vehicle>> search(int seat ,DateTime checkIn, DateTime checkOut);
    }
}
