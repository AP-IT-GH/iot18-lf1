using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Repositories;

namespace Services
{
    public class PictureService
    {
        private PicturesRepository _pictureRepository;
        private CameraRepository _cameraRepository;

        public PictureService(PicturesRepository picturesRepository, CameraRepository cameraRepository)
        {
            _pictureRepository = picturesRepository;
            _cameraRepository = cameraRepository;
        }

        public PictureModel Create(PictureModel picture)
        {
            picture.TimeStamp = DateTime.Now;
            picture.Camera = _cameraRepository.Get(picture.CameraId);
            return _pictureRepository.Post(picture);
        }

        public PictureModel Update(PictureModel picture)
        {
            picture.Camera = _cameraRepository.Get(picture.CameraId);
            return _pictureRepository.Put(picture);
        }

        public bool Delete(int id)
        {
            return _pictureRepository.Delete(id);
        }

        public List<PictureModel> GetAll()
        {
            return _pictureRepository.GetAll();
        }

        public PictureModel Get(int id)
        {
            return _pictureRepository.Get(id);
        }
    }
}
