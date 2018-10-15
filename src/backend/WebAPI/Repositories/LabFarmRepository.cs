using System;
using System.Collections.Generic;
using System.Linq;
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

            public List<LabFarmModel> GetAll()
            {
                try
                {
                    return _context.LabFarms.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            public LabFarmModel Get(long id)
            {
                try
                {
                    return _context.LabFarms.Find(id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            public LabFarmModel Put(LabFarmModel labfarm)
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

            public LabFarmModel Post(LabFarmModel labfarm)
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
            public bool Delete(long id)
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
