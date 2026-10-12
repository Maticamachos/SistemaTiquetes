using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STP.DataAccess.Entity;

namespace STP.DataAccess.Entity
{
    public interface IEntity
    {
        string UniqueIdentifier { set; get; }
    }
}