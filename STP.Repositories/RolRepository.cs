using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STP.DataAccess;


namespace STP.Repositories
{
    public class RolRepository : RepositoryBase<STP_ROL>

    {

        public IEnumerable<STP_ROL> MyRoles()
        {
            return _context.Set<STP_ROL>().ToList();
        }

    }
}
