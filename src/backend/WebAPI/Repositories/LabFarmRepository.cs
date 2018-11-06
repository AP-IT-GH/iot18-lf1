using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    // DB calls
    public class LabFarmRepository
    {

            private CollectionContext _context;
            public LabFarmRepository(CollectionContext context)
            {
                _context = context;
            }

            public List<LabFarm> GetAll()
            {
                try
                {
                return _context.LabFarms.Include(d => d.Plants)
                                            .ThenInclude(d => d.Pictures)
                                                .Include(d => d.Sensors)
                                                    .ThenInclude(d => d.SensorValues)
                                                        .Include(d => d.Sensors)
                                                            .ThenInclude(d => d.SensorType).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            public LabFarm Get(int id)
            {
                try
                {
                return _context.LabFarms.Include(d => d.Plants)
                                            .ThenInclude(d => d.Pictures)
                                                .Include(d => d.Sensors)
                                                    .ThenInclude(d => d.SensorValues)
                                                        .Include(d => d.Sensors)
                                                            .ThenInclude(d => d.SensorType).SingleOrDefault(d => d.Id == id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            public LabFarm Put(LabFarm labfarm)
            {
                try
                {
                    _context.LabFarms.Update(labfarm);
                    _context.SaveChanges();
                    return labfarm;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public LabFarm Post(LabFarm labfarm)
            {
                try
                {
                    _context.LabFarms.Add(labfarm);
                    _context.SaveChanges();
                    return labfarm;
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
                    var labfarm = _context.LabFarms.Find(id);
                    if (labfarm == null)
                    {
                        return false;
                    }

                    _context.LabFarms.Remove(labfarm);
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
