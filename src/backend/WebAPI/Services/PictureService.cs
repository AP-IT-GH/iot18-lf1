using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Repositories;

namespace Services
{
    public class PictureService
    {
        private PicturesRepository _repository;

        public PictureService(PicturesRepository repository)
        {
            _repository = repository;
        }

        public PictureModel Create(PictureModel picture)
        {
            return _repository.Post(picture);
        }

        public PictureModel Update(PictureModel picture)
        {
            return _repository.Put(picture);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<PictureModel> GetAll()
        {
            return _repository.GetAll();
        }

        public PictureModel Get(int id)
        {
            return _repository.Get(id);
        }
    }
}
