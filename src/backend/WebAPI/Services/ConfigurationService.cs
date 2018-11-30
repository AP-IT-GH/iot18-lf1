using System;
using System.Collections.Generic;
using System.Text;
using Repositories;
using Models;

namespace Services
{
    public class ConfigurationService
    {
        private ConfigurationRepository _configRepository;

        public ConfigurationService(ConfigurationRepository configRepository)
        {
            _configRepository = configRepository;
        }

        public Configuration Create(Configuration picture)
        {
            return _configRepository.Post(picture);
        }

        public Configuration Update(Configuration picture)
        {
            return _configRepository.Put(picture);
        }

        public bool Delete(int id)
        {
            return _configRepository.Delete(id);
        }

        public List<Configuration> GetAll()
        {
            return _configRepository.GetAll();
        }

        public Configuration Get(int id)
        {
            return _configRepository.Get(id);
        }

    }
}
