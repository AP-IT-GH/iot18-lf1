using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace Repositories
{
    // DB calls
    public class ConfigurationRepository
    {
        private CollectionContext _context;
        public ConfigurationRepository(CollectionContext context)
        {
            _context = context;
        }

        public List<Configuration> GetAll()
        {
            try
            {
                return _context.Configurations.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Configuration Get(int id)
        {
            try
            {
                return _context.Configurations.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Configuration Put(Configuration config)
        {
            try
            {
                _context.Configurations.Update(config);
                _context.SaveChanges();
                return config;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Configuration Post(Configuration config)
        {
            try
            {
                _context.Configurations.Add(config);
                _context.SaveChanges();
                return config;
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
                var config = _context.Configurations.Find(id);
                if (config == null)
                {
                    return false;
                }

                _context.Configurations.Remove(config);
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
