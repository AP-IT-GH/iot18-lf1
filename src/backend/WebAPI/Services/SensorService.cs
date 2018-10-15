using System;
using System.Collections.Generic;
using System.Text;
using Repositories;
using Models;

namespace Services
{
    //Bussines logic
    public class SensorService
    {
        private SensorRepository _repository;

        public SensorService(SensorRepository repository)
        {
            _repository = repository;
        }

        public SensorModel Create(SensorModel sensor)
        {
            return _repository.Post(sensor);
        }

        public SensorModel Update(SensorModel sensor)
        {
            return _repository.Put(sensor);
        }

        public bool Delete(long id)
        {
            return _repository.Delete(id);
        }

        public List<SensorModel> GetAll()
        {
            return _repository.GetAll();
        }

        public SensorModel Get(long id)
        {
            return _repository.Get(id);
        }

    }
}
