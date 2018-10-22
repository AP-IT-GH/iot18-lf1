using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    // DB calls
    public class PicturesRepository
    {
        private CollectionContext _context;
        public PicturesRepository(CollectionContext context)
        {
            _context = context;
        }

        public List<PictureModel> GetAll()
        {
            try
            {
                return _context.Pictures.Include(d => d.Camera).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public PictureModel Get(int id)
        {
            try
            {
                return _context.Pictures.Include(d => d.Camera).SingleOrDefault(d => d.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public PictureModel Put(PictureModel picture)
        {
            try
            {
                _context.Pictures.Update(picture);
                _context.SaveChanges();
                return picture;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PictureModel Post(PictureModel picture)
        {
            try
            {
                _context.Pictures.Add(picture);
                _context.SaveChanges();
                return picture;
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
                var picture = _context.Pictures.Find(id);
                if (picture == null)
                {
                    return false;
                }

                _context.Pictures.Remove(picture);
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
