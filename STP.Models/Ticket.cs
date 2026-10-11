using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP.Models
{
    public class Ticket
    {

        public int TicketId { get; set; }
        public string EventName { get; set; }
        public string TicketType { get; set; }
        public decimal Price { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public int EstadoId { get; set; }
        public int UsuarioId { get; set; }
    }
}
