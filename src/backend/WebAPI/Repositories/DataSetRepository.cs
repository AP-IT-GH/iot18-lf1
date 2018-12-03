using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace Repositories
{
    public class DataSetRepository
    {
        private CollectionContext _context;
        public DataSetRepository(CollectionContext context)
        {
            _context = context;
        }

        public List<PlantDataSet> GetAll()
        {
            try
            {
                return _context.DataSets.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public PlantDataSet Get(int id)
        {
            try
            {
                return _context.DataSets.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public PlantDataSet Put(PlantDataSet dataSet)
        {
            try
            {
                _context.DataSets.Update(dataSet);
                _context.SaveChanges();
                return dataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PlantDataSet Post(PlantDataSet dataSet)
        {
            try
            {
                _context.DataSets.Add(dataSet);
                _context.SaveChanges();
                return dataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool Delete(int id)
        {
            try
            {
                var dataSet = _context.Plants.Find(id);
                if (dataSet == null)
                {
                    return false;
                }

                _context.Plants.Remove(dataSet);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

