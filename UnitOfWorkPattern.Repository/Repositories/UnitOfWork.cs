using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkPattern.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private CarRentalDBContext _baseContext;
        private Repository<Account> _Account;
        private Repository<User> _User;
        private Repository<Garage> _Garage;
        private Repository<Category> _Category;
        public UnitOfWork(CarRentalDBContext baseContext)
        {
            _baseContext = baseContext;
        }

        public IRepository<Account> Account
        {
            get
            {
                return _Account ?? (_Account = new Repository<Account>(_baseContext));
            }
        }

        public IRepository<User> User
        {
            get
            {
                return _User ?? (_User = new Repository<User>(_baseContext));
            }
        }
        public IRepository<Garage> Garage
        {
            get
            {
                return _Garage ?? (_Garage = new Repository<Garage>(_baseContext));
            }
        }

        public IRepository<Category> Category
        {
            get
            {
                return _Category ?? (_Category = new Repository<Category>(_baseContext));
            }
        }
    }
}
