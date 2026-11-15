using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using STP.DataAccess;


namespace STP.Repositories
{
    public class StatusRepository : RepositoryBase<STP_ESTADO>

    {

        public IEnumerable<STP_ESTADO> MyStatus()
        {
            return _context.Set<STP_ESTADO>().ToList();
        }

    }
}
