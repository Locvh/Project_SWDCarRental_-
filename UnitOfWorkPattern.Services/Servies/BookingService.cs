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
  public  class BookingService : IBookingService  // dùng để gọi các Repository lên và có thể làm các business logic ở trong đây
    {
        private readonly IBookingRepository _BookingRepository;

        private readonly CarRentalDBContext _context;

        private IUnitOfWork _unitOfWork;

        public BookingService(IBookingRepository BookingRepository, CarRentalDBContext context, IUnitOfWork unitOfWork)
        {
            _BookingRepository = BookingRepository;
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public async Task<Booking> AddBookingAsync(Booking newBooking)
        {
            Booking Booking = new Booking
            {
                Phone = newBooking.Phone,
                FullName = newBooking.FullName,
                AccountId = newBooking.AccountId,
                TotalPayment=newBooking.TotalPayment
            };
            return await _BookingRepository.AddAsync(Booking);
        }


        public async Task<Booking> DeleteAllBookingAsync(int id)
        {
            var Booking = _unitOfWork.Booking.GetByID(id);
            return await _BookingRepository.DeleteAllAsync(Booking);
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _BookingRepository.GetBookingByIdAsync(id);
        }

        public async Task<List<Booking>> GetAllBookingsAsyncPage(Pagging pagging)
        {
            return await _BookingRepository.GetAllBookingsAsyncPage(pagging);
        }

    }
}