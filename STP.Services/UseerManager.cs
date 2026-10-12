using STP.Models;
using STP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STP.DataAccess;

namespace STP.Services
{
public class UseerManager
    {
        private readonly UserRepository _repository;

        public UseerManager()
        {
            _repository = new UserRepository();
        }

        public IEnumerable<STP_USUARIO> GetAllTickets()
        {
            return _repository.GetAll();
        }
    }
}
