using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using STP.Models;
using STP.Repositories;
using STP.DataAccess;

namespace STP.Services
{
    public class TicketManager
    {
        private readonly TicketRepository _repository;

        public TicketManager()
        {
            _repository = new TicketRepository();
        }

        public IEnumerable<STP_TICKET> GetAllTickets()
        {
            return _repository.GetAll();
        }
    }
}
