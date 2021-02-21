using Project_SWDCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkPattern.Repository.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Account> Account { get; }
        IRepository<User> User { get; }

        IRepository<Category> Category { get; }
        IRepository<Garage> Garage { get; }

        IRepository<Vehicle> Vehicle { get; }
    }
}
