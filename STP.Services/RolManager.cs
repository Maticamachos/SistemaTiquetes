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
    public class RolManager
    {
        private readonly RolRepository _repository;

        public RolManager()
        {
            _repository = new RolRepository();
        }

        public IEnumerable<STP_ROL> GetAllRolesFromDataModel()
        {
            return _repository.GetAll();
        }

        public STP_ROL GetRolFromID(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(STP_ROL rol)
        {
            _repository.Add(rol);
        }

        public void Update(STP_ROL rol)
        {
            _repository.Update(rol);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}

