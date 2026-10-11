using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP.Models
{
    public class User
    {

        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public int EstadoId { get; set; }
        public int RolId { get; set; }
        

    }
}
