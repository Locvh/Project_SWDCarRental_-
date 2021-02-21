using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkPattern.Repository.Models;
using UnitOfWorkPattern.Repository.Repositories;

namespace UnitOfWorkPattern.Services.Servies
{
  public class VehicleService : IVehicleService  // dùng để gọi các Repository lên và có thể làm các business logic ở trong đây
    {
        private readonly IVehicleRepository _VehicleRepository;

        private readonly CarRentalDBContext _context;

        private IUnitOfWork _unitOfWork;

        public VehicleService(IVehicleRepository VehicleRepository, CarRentalDBContext context, IUnitOfWork unitOfWork)
        {
            _VehicleRepository = VehicleRepository;
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public async Task<Vehicle> AddVehicleAsync(Vehicle newVehicle)
        {
            Vehicle Vehicle = new Vehicle
            {
                CateId = newVehicle.CateId,
                VehicleFare = newVehicle.VehicleFare,
                Seat = newVehicle.Seat,
                DescriptionCar = newVehicle.DescriptionCar,
                Status = true,
                ImageLink = newVehicle.ImageLink,
                LicensePlates = newVehicle.LicensePlates,
                Brand= newVehicle.Brand,
                CheckInDate = newVehicle.CheckInDate,
                CheckOutDate = newVehicle.CheckOutDate,
                GarageId = newVehicle.GarageId

            };
            return await _VehicleRepository.AddAsync(Vehicle);
        }

        public async Task<Vehicle> DeleteVehicleAsync(int id)
        {
            var Vehicle = _unitOfWork.Vehicle.GetByID(id);
            Vehicle.Status = false;
            return await _VehicleRepository.DeleteAsync(Vehicle);
        }

        public async Task<Vehicle> DeleteAllVehicleAsync(int id)
        {
            var Vehicle = _unitOfWork.Vehicle.GetByID(id);
            return await _VehicleRepository.DeleteAllAsync(Vehicle);
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
            return await _VehicleRepository.GetVehicleByIdAsync(id);
        }



        public async Task<List<Vehicle>> GetAllVehiclesAsync()
        {
            return await _VehicleRepository.GetAllVehiclesAsync();
        }

        public async Task<List<Vehicle>> GetAllVehiclesStatusFalseAsync()
        {
            return await _VehicleRepository.GetAllVehiclesStatusFalseAsync();
        }

        public async Task<List<Vehicle>> GetAllVehiclesAsyncPage(Pagging pagging)
        {
            return await _VehicleRepository.GetAllVehiclesAsyncPage(pagging);
        }

        public async Task<List<Vehicle>> GetAllVehiclesAsyncPageStatusFalse(Pagging pagging)
        {
            return await _VehicleRepository.GetAllVehiclesAsyncPageStatusFalse(pagging);
        }

        public async Task<IEnumerable<Vehicle>> Search(int seat, DateTime checkIn, DateTime checkOut)
        {
            return await _VehicleRepository.search(seat,checkIn,checkOut);
        }

        public async Task<Vehicle> UpdateVehicleAsync(int id, Vehicle newVehicle)
        {
            var Vehicle = _unitOfWork.Vehicle.GetByID(id);
            Vehicle.VehicleFare = newVehicle.VehicleFare;
            Vehicle.Seat = newVehicle.Seat;
            Vehicle.DescriptionCar = newVehicle.DescriptionCar;
            Vehicle.ImageLink = newVehicle.ImageLink;
            Vehicle.LicensePlates = newVehicle.LicensePlates;
            Vehicle.Brand= newVehicle.Brand;
            Vehicle.CheckInDate = newVehicle.CheckInDate;
            Vehicle.CheckOutDate = newVehicle.CheckOutDate;
            return await _VehicleRepository.UpdateAsync(Vehicle);
        }


    }
}