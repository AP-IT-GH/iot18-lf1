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

        public PictureService(PicturesRepository picturesRepository )
        {
            _pictureRepository = picturesRepository;
        }

        public Picture Create(Picture picture)
        {
            picture.TimeStamp = DateTime.Now;
            return _pictureRepository.Post(picture);
        }

        public Picture Update(Picture picture)
        {
            return _pictureRepository.Put(picture);
        }

        public bool Delete(int id)
        {
            return _pictureRepository.Delete(id);
        }

        public List<Picture> GetAll()
        {
            return _pictureRepository.GetAll();
        }

        public Picture Get(int id)
        {
            return _pictureRepository.Get(id);
        }
 
    }
}
