using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STP.Models;
using STP.Repositories;
using STP.DataAccess;

namespace STP.Services
{
    public class RolManager
    {
        private readonly RolRepository _repository;

        public RolManager()
        {
            _repository = new RolRepository();
        }

        public IEnumerable<STP_ROL> GetAllTickets()
        {
            return _repository.GetAll();
        }
    }
}

