using System.Collections.Generic;
using Repositories;
using Models;

namespace Services
{
    //Bussines logic
    public class CameraService
    {
        private CameraRepository _cameraRepository;
        private LabFarmRepository _labFarmRepository;

        public CameraService(CameraRepository cameraRepository, LabFarmRepository labFarmRepository)
        {
            _cameraRepository = cameraRepository;
            _labFarmRepository = labFarmRepository;
        }

        public CameraModel Create(CameraModel camera)
        {
            camera.Labfarm = _labFarmRepository.Get(camera.LabfarmId);
            return _cameraRepository.Post(camera);
        }

        public CameraModel Update(CameraModel camera)
        {
            camera.Labfarm = _labFarmRepository.Get(camera.LabfarmId);
            return _cameraRepository.Put(camera);
        }

        public bool Delete(int id)
        {
            return _cameraRepository.Delete(id);
        }

        public List<CameraModel> GetAll()
        {
            return _cameraRepository.GetAll();
        }

        public CameraModel Get(int id)
        {
            return _cameraRepository.Get(id);
        }
    }
}
