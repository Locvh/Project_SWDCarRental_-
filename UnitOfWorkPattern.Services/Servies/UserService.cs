using Microsoft.AspNetCore.Mvc;
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
   public class UserService : IUserService  // dùng để gọi các Repository lên và có thể làm các business logic ở trong đây
    {
        private readonly IUserRepository _UserRepository;

        private readonly CarRentalDBContext _context;

        private IUnitOfWork _unitOfWork;

        public UserService(IUserRepository UserRepository, CarRentalDBContext context, IUnitOfWork unitOfWork)
        {
            _UserRepository = UserRepository;
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public async Task<User> AddUserAsync(User newUser)
        {
            User user = new User
            {
                ProfileImage = newUser.ProfileImage,
                Phone = newUser.Phone,
                Email = newUser.Email,
                Address = newUser.Address,
                IdentityCard = newUser.IdentityCard,
                FullName= newUser.FullName,
                AccountId= newUser.AccountId,
                Status = true

            };
            return await _UserRepository.AddAsync(user);
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            var User = _unitOfWork.User.GetByID(id);
            User.Status = false;
            return await _UserRepository.DeleteAsync(User);
        }

        public async Task<User> DeleteAllUserAsync(int id)
        {
            var User = _unitOfWork.User.GetByID(id);
            return await _UserRepository.DeleteAllAsync(User);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _UserRepository.GetUserByIdAsync(id);
        }



        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _UserRepository.GetAllUsersAsync();
        }

        public async Task<List<User>> GetAllUsersStatusFalseAsync()
        {
            return await _UserRepository.GetAllUsersStatusFalseAsync();
        }

        public async Task<List<User>> GetAllUsersAsyncPage(Pagging pagging)
        {
            return await _UserRepository.GetAllUsersAsyncPage(pagging);
        }

        public async Task<List<User>> GetAllUsersAsyncPageStatusFalse(Pagging pagging)
        {
            return await _UserRepository.GetAllUsersAsyncPageStatusFalse(pagging);
        }

        public async Task<IEnumerable<User>> Search(string fullname)
        {
            return await _UserRepository.search(fullname);
        }

        public async Task<User> UpdateUserAsync(int id, User newUser)
        {
            var User = _unitOfWork.User.GetByID(id);
            User.ProfileImage = newUser.ProfileImage;
            User.Phone = newUser.Phone;
            User.Email = newUser.Email;
            User.Address = newUser.Address;
            User.IdentityCard = newUser.IdentityCard;
            User.FullName = newUser.FullName;
            return await _UserRepository.UpdateAsync(User);
        }


    }
}
