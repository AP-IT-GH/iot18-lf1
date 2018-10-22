using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    // DB calls
    public class SensorRepository
    {
        private CollectionContext _context;
        public SensorRepository(CollectionContext context)
        {
            _context = context;
        }

        public List<SensorModel> GetAll()
        {
            try
            {
                return _context.Sensors.Include(d => d.LabFarm).Include(d => d.SensorType).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public SensorModel Get(long id)
        {
            try
            {
                return _context.Sensors.Include(d => d.LabFarm).Include(d => d.SensorType).SingleOrDefault(d => d.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public SensorModel Put(SensorModel sensor)
        {
            try
            {
                _context.Sensors.Update(sensor);
                _context.SaveChanges();
                return sensor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SensorModel Post(SensorModel sensor)
        {
            try
            {
                _context.Sensors.Add(sensor);
                _context.SaveChanges();
                return sensor;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool Delete(long id)
        {
            try
            {
                var sensor = _context.Sensors.Find(id);
                if (sensor == null)
                {
                    return false;
                }

                _context.Sensors.Remove(sensor);
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
