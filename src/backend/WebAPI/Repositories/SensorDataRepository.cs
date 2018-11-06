using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    // DB calls
    public class SensorDataRepository
    {
        private CollectionContext _context;
        public SensorDataRepository(CollectionContext context)
        {
            _context = context;
        }

        public List<SensorData> GetAll()
        {
            try
            {
                return _context.SensorValues.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public SensorData Get(int id)
        {
            try
            {
                return _context.SensorValues.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public SensorData Put(SensorData value)
        {
            try
            {
                _context.SensorValues.Update(value);
                _context.SaveChanges();
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SensorData Post(SensorData value)
        {
            try
            {
                _context.SensorValues.Add(value);
                _context.SaveChanges();
                return value;
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
                var value = _context.SensorValues.Find(id);
                if (value == null)
                {
                    return false;
                }

                _context.SensorValues.Remove(value);
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
