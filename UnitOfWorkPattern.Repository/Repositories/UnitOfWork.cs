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
    }
}
