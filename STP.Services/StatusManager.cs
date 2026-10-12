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
  
    public class StatusManager
    {
        private readonly StatusRepository _repository;

        public StatusManager()
        {
            _repository = new StatusRepository();
        }

        public IEnumerable<STP_ESTADO> GetAllTickets()
        {
            return _repository.GetAll();
        }
    }
}
