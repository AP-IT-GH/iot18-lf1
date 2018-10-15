using System.Collections.Generic;
using Repositories;
using Models;

namespace Services
{
    //Bussines logic
    public class CameraService
    {
        private CameraRepository _repository;

        public CameraService(CameraRepository repository)
        {
            _repository = repository;
        }

        public CameraModel Create(CameraModel camera)
        {
            return _repository.Post(camera);
        }

        public CameraModel Update(CameraModel camera)
        {
            return _repository.Put(camera);
        }

        public bool Delete(long id)
        {
            return _repository.Delete(id);
        }

        public List<CameraModel> GetAll()
        {
            return _repository.GetAll();
        }

        public CameraModel Get(long id)
        {
            return _repository.Get(id);
        }
    }
}
