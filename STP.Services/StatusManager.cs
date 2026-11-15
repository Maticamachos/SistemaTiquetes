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

    public class StatusManager
    {
        private readonly StatusRepository _repository;

        public StatusManager()
        {
            _repository = new StatusRepository();
        }

        public IEnumerable<STP_ESTADO> GetAllEstadosFromDataModel()
        {
            return _repository.GetAll();
        }

        public STP_ESTADO GetEstadoFromID(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(STP_ESTADO estado)
        {
            _repository.Add(estado);
        }

        public void Update(STP_ESTADO estado)
        {
            _repository.Update(estado);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}