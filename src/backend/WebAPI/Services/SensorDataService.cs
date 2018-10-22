using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Repositories;

namespace Services
{
    public class SensorDataService
    {
        private SensorDataRepository _repository;

        public SensorDataService(SensorDataRepository repository)
        {
            _repository = repository;
        }

        public SensorDataModel Create(SensorDataModel data)
        {
            return _repository.Post(data);
        }

        public SensorDataModel Update(SensorDataModel data)
        {
            return _repository.Put(data);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<SensorDataModel> GetAll()
        {
            return _repository.GetAll();
        }

        public SensorDataModel Get(int id)
        {
            return _repository.Get(id);
        }
    }
}
