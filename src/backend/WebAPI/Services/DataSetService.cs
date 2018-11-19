using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Repositories;

namespace Services
{
    public class DataSetService
    {
        private DataSetRepository _dataSetRepository;

        public DataSetService(DataSetRepository dataSetRepository)
        {
            _dataSetRepository = dataSetRepository;
        }

        public PlantDataSet Create(PlantDataSet picture)
        {
            return _dataSetRepository.Post(picture);
        }

        public PlantDataSet Update(PlantDataSet picture)
        {
            return _dataSetRepository.Put(picture);
        }

        public bool Delete(int id)
        {
            return _dataSetRepository.Delete(id);
        }

        public List<PlantDataSet> GetAll()
        {
            return _dataSetRepository.GetAll();
        }

        public PlantDataSet Get(int id)
        {
            return _dataSetRepository.Get(id);
        }

        public List<string> GetPlants()
        {
            var names = new List<string>();
            var dataSets = GetAll();
            foreach(PlantDataSet p in dataSets)
            {
                names.Add(p.PlantSpecies);
            }
            return names;
        }
    }
}
