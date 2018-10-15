using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Repositories;

namespace Services
{
    //Bussines logic
    public class LabFarmService
    {
        private LabFarmRepository _repository;

        public LabFarmService(LabFarmRepository repository)
        {
            _repository = repository;
        }

        public LabFarmModel Create(LabFarmModel labfarm)
        {
            return _repository.Post(labfarm);
        }

        public LabFarmModel Update(LabFarmModel labfarm)
        {
            return _repository.Put(labfarm);
        }

        public bool Delete(long id)
        {
            return _repository.Delete(id);
        }

        public List<LabFarmModel> GetAll()
        {
            return _repository.GetAll();
        }

        public LabFarmModel Get(long id)
        {
            return _repository.Get(id);
        }
    }
}
