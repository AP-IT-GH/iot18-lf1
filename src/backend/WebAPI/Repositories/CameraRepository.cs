using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;


namespace Repositories
{
    // DB calls
    public class CameraRepository 
    {
        private CollectionContext _context;
        public CameraRepository(CollectionContext context)
        {
            _context = context;
        }

        public List<CameraModel> GetAll()
        {
            try
            {
                return _context.Cameras.Include(d => d.Labfarm).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public CameraModel Get(int id)
        {
            try
            {
                return _context.Cameras.Include(d => d.Labfarm).SingleOrDefault(d => d.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public CameraModel Put(CameraModel camera)
        {
            try
            {
                _context.Cameras.Update(camera);
                _context.SaveChanges();
                return camera;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CameraModel Post(CameraModel camera)
        {
            try
            {
                _context.Cameras.Add(camera);
                _context.SaveChanges();
                return camera;
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
                var camera = _context.Cameras.Find(id);
                if (camera == null)
                {
                    return false;
                }

                _context.Cameras.Remove(camera);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
