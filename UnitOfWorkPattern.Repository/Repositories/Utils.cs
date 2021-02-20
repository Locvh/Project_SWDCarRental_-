using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkPattern.Repository.Repositories
{
    public static class Utils
    {

        public static JsonResult success(object data)
        {
            object c = new
            {
                data = data
            };
            return new JsonResult(c);
        }
    }
}
