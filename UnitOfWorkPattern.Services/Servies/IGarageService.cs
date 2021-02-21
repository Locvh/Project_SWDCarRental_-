using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkPattern.Services.Servies
{
   public interface IGarageService
    {
        Task<List<Garage>> GetAllGaragesAsync();

        Task<Garage> GetGarageByIdAsync(int id);

        Task<IEnumerable<Garage>> Search(string address);
      
        Task<Garage> AddGarageAsync(Garage newGarage);
        Task<Garage> UpdateGarageAsync(int id, Garage newGarage);
        Task<Garage> DeleteAllGarageAsync(int id);
    }
}
