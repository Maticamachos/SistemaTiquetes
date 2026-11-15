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
    public class UserManager
    {
        private readonly UserRepository _repository;

        public UserManager()
        {
            _repository = new UserRepository();



        }

        public IEnumerable<STP_USUARIO> GetAllUsuariosFromDataModel()
        {
            return _repository.GetAll();
        }

        public STP_USUARIO GetUsuarioFromID(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(STP_USUARIO usuario)
        {
            _repository.Add(usuario);
        }

        public void Update(STP_USUARIO usuario)
        {
            _repository.Update(usuario);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
