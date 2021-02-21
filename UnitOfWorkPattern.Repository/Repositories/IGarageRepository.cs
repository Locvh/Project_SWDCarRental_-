using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkPattern.Repository.Repositories
{
    public interface IGarageRepository : IRepository<Garage>
    {
        Task<Garage> GetGarageByIdAsync(int id);

        Task<List<Garage>> GetAllGaragesAsync();


        Task<IEnumerable<Garage>> search(string Address);
    }
}