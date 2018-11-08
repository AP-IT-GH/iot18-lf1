using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;


namespace Repositories
{
    // DB calls
    public class PlantRepository 
    {
        private CollectionContext _context;
        public PlantRepository(CollectionContext context)
        {
            _context = context;
        }

        public List<Plant> GetAll()
        {
            try
            {
                return _context.Plants.Include(d => d.Pictures).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Plant> GetAllIncludingLabfarm()
        {
            try
            {
                return _context.Plants.Include(d => d.Pictures).Include(d => d.Labfarm).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Plant Get(int id)
        {
            try
            {
                return _context.Plants.Include(d => d.Pictures).SingleOrDefault(d => d.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Plant Put(Plant plant)
        {
            try
            {
                _context.Plants.Update(plant);
                _context.SaveChanges();
                return plant;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Plant Post(Plant plant)
        {
            try
            {
                _context.Plants.Add(plant);
                _context.SaveChanges();
                return plant;
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
                var plant = _context.Plants.Find(id);
                if (plant == null)
                {
                    return false;
                }

                _context.Plants.Remove(plant);
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
