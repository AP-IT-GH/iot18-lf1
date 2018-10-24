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

        public List<SensorDataModel> GetAll()
        {
            try
            {
                return _context.SensorValues.Include(d => d.Sensor).ThenInclude(b => b.SensorType).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public SensorDataModel Get(int id)
        {
            try
            {
                return _context.SensorValues.Include(d => d.Sensor).ThenInclude(b => b.SensorType).SingleOrDefault(d => d.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public SensorDataModel Put(SensorDataModel value)
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

        public SensorDataModel Post(SensorDataModel value)
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
