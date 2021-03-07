using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkPattern.Repository.Models;

namespace UnitOfWorkPattern.Services.Servies
{
   public interface IVehicleService
    {
        Task<Vehicle> GetVehicleByIdAsync(int id);

        Task<IEnumerable<Vehicle>> Search(int seat,DateTime checkIn,DateTime checkOut);
        Task<List<Vehicle>> GetAllVehiclesAsyncPage(Pagging pagging);
        Task<List<Vehicle>> GetAllVehiclesAsyncPageStatusFalse(Pagging pagging);

        Task<Vehicle> AddVehicleAsync(Vehicle newVehicle);
        Task<Vehicle> UpdateVehicleAsync(int id, Vehicle newVehicle);
        Task<Vehicle> DeleteVehicleAsync(int id);
        Task<Vehicle> DeleteAllVehicleAsync(int id);
    }
}
