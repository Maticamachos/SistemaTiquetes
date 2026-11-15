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

        public IEnumerable<STP_TICKET> GetAllTicketsFromDataModel()
        {
            return _repository.GetAll();
        }

        public STP_TICKET GetTicketFromID(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(STP_TICKET ticket)
        {
            _repository.Add(ticket);
        }

        public void Update(STP_TICKET ticket)
        {
            _repository.Update(ticket);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
