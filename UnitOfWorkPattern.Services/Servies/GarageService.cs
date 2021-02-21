using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkPattern.Repository.Repositories;

namespace UnitOfWorkPattern.Services.Servies
{
   public class GarageService : IGarageService  // dùng để gọi các Repository lên và có thể làm các business logic ở trong đây
    {
        private readonly IGarageRepository _GarageRepository;

        private readonly CarRentalDBContext _context;

        private IUnitOfWork _unitOfWork;

        public GarageService(IGarageRepository GarageRepository, CarRentalDBContext context, IUnitOfWork unitOfWork)
        {
            _GarageRepository = GarageRepository;
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public async Task<Garage> AddGarageAsync(Garage newGarage)
        {
            Garage Garage = new Garage
            {
                Address=newGarage.Address,
                Description=newGarage.Description,
                ImageLink=newGarage.ImageLink,

            };
            return await _GarageRepository.AddAsync(Garage);
        }


        public async Task<Garage> DeleteAllGarageAsync(int id)
        {
            var Garage = _unitOfWork.Garage.GetByID(id);
            return await _GarageRepository.DeleteAllAsync(Garage);
        }

        public async Task<Garage> GetGarageByIdAsync(int id)
        {
            return await _GarageRepository.GetGarageByIdAsync(id);
        }



        public async Task<List<Garage>> GetAllGaragesAsync()
        {
            return await _GarageRepository.GetAllGaragesAsync();
        }

     
        public async Task<IEnumerable<Garage>> Search(string address)
        {
            return await _GarageRepository.search(address);
        }

        public async Task<Garage> UpdateGarageAsync(int id, Garage newGarage)
        {
            var Garage = _unitOfWork.Garage.GetByID(id);
            Garage.Address = newGarage.Address;
            Garage.Description = newGarage.Description;
            Garage.ImageLink = newGarage.ImageLink;
            return await _GarageRepository.UpdateAsync(Garage);
        }


    }
}