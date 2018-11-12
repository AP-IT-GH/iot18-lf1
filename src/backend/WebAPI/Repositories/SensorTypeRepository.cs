using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    // DB calls
    public class SensorTypeRepository
    {
        private CollectionContext _context;
        public SensorTypeRepository(CollectionContext context)
        {
            _context = context;
        }

        public List<SensorType> GetAll()
        {
            try
            {
                return _context.SensorTypes.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<SensorType> GetAllIncludingLabfarm()
        {
            try
            {
                return _context.SensorTypes.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public SensorType Get(int id)
        {
            try
            {
                return _context.SensorTypes.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public SensorType Put(SensorType type)
        {
            try
            {
                _context.SensorTypes.Update(type);
                _context.SaveChanges();
                return type;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SensorType Post(SensorType type)
        {
            try
            {
                _context.SensorTypes.Add(type);
                _context.SaveChanges();
                return type;
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
                var type = _context.SensorTypes.Find(id);
                if (type == null)
                {
                    return false;
                }

                _context.SensorTypes.Remove(type);
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
