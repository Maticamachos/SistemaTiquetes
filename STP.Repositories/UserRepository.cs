using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using STP.DataAccess;


namespace STP.Repositories
{
    public class UserRepository : RepositoryBase<STP_USUARIO>

    {

        public IEnumerable<STP_USUARIO> MyUsers()
        {
            return _context.Set<STP_USUARIO>().ToList();
        }

    }
}
