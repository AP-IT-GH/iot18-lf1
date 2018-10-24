using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<LabFarmModel> GetAll(string userId)
        {
            var list = _repository.GetAll();

            if (userId == null || userId == "")
            {
                return list;
            }
            
            List<LabFarmModel> updatedList = new List<LabFarmModel>();
            foreach(LabFarmModel x in list)
            {
                if(x.AuthId == userId)
                {
                    updatedList.Add(x);
                }
            }
            return updatedList;
        }

        public LabFarmModel Get(int id)
        {
            return _repository.Get(id);
        }
    }
}
