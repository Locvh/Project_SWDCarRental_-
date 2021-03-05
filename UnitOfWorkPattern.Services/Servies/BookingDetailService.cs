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
  public  class BookingDetailService : IBookingDetailService  // dùng để gọi các Repository lên và có thể làm các business logic ở trong đây
    {
        private readonly IBookingDetailRepository _BookingDetailRepository;

        private readonly CarRentalDBContext _context;

        private IUnitOfWork _unitOfWork;

        public BookingDetailService(IBookingDetailRepository BookingDetailRepository, CarRentalDBContext context, IUnitOfWork unitOfWork)
        {
            _BookingDetailRepository = BookingDetailRepository;
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public async Task<BookingDetail> AddBookingDetailAsync(BookingDetail newBookingDetail)
        {
            BookingDetail BookingDetail = new BookingDetail
            {
                ResId = newBookingDetail.ResId,
                VelNo = newBookingDetail.VelNo,
                AmountOfMoney = newBookingDetail.AmountOfMoney,
                FromDate=newBookingDetail.FromDate,
                ToDate=newBookingDetail.ToDate
            };
            return await _BookingDetailRepository.AddAsync(BookingDetail);
        }


        public async Task<BookingDetail> DeleteAllBookingDetailAsync(int id)
        {
            var BookingDetail = _unitOfWork.BookingDetail.GetByID(id);
            return await _BookingDetailRepository.DeleteAllAsync(BookingDetail);
        }

        public async Task<BookingDetail> GetBookingDetailByIdAsync(int id)
        {
            return await _BookingDetailRepository.GetBookingDetailByIdAsync(id);
        }

        //public async Task<List<BookingDetail>> GetAllBookingDetailsAsync()
        //{
        //    return await _BookingDetailRepository.GetAllBookingDetailsAsync();
        //}

        public async Task<List<BookingDetail>> GetAllBookingDetailsAsyncPage(Pagging pagging)
        {
            return await _BookingDetailRepository.GetAllBookingDetailsAsyncPage(pagging);
        }

        public async Task<BookingDetail> UpdateBookingDetailAsync(int id, BookingDetail newBookingDetail)
        {
            var BookingDetail = _unitOfWork.BookingDetail.GetByID(id);
            BookingDetail.AmountOfMoney = newBookingDetail.AmountOfMoney;
            BookingDetail.ToDate = newBookingDetail.ToDate;
            return await _BookingDetailRepository.UpdateAsync(BookingDetail);
        }


    }
}