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

        public List<Sensor> GetAll()
        {
            try
            {
                return _context.Sensors.Include(d => d.SensorValues).Include(d => d.SensorType).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Sensor> GetAllIncludingLabfarm()
        {
            try
            {
                return _context.Sensors.Include(d => d.SensorValues).Include(d => d.SensorType).Include(d => d.LabFarm).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Sensor Get(int id)
        {
            try
            {
                return _context.Sensors.Include(d => d.SensorValues).Include(d => d.SensorType).SingleOrDefault(d => d.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Sensor Put(Sensor sensor)
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

        public Sensor Post(Sensor sensor)
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
        public bool Delete(int id)
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
