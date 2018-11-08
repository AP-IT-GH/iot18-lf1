using System.Collections.Generic;
using Repositories;
using Models;
using ViewModels;
using System.Linq;

namespace Services
{
    //Bussines logic
    public class PlantService
    {
        private PlantRepository _plantRepository;

        public PlantService(PlantRepository plantRepository )
        {
            _plantRepository = plantRepository;
        }

        public Plant Create(Plant plant)
        {
            return _plantRepository.Post(plant);
        }

        public Plant Update(Plant plant)
        {
            return _plantRepository.Put(plant);
        }

        public bool Delete(int id)
        {
            return _plantRepository.Delete(id);
        }

        public List<Plant> GetAll()
        {
            return _plantRepository.GetAll();
        }

        public Plant Get(int id)
        {
            return _plantRepository.Get(id);
        }

        public List<LastPictures> GetLastPictures(int id, int count)
        {
            if(count == 0)
            {
                count = 999;
            }
            var plants = _plantRepository.GetAllIncludingLabfarm();
            var plants2 = new List<Plant>();
            foreach (Plant s in plants)
            {
                if (s.Labfarm.Id == id)
                {
                    plants2.Add(s);
                }
            }

            var lastPictures = new List<LastPictures>();
            foreach(Plant s in plants2)
            {
                s.Pictures = s.Pictures.OrderByDescending(x => x.TimeStamp.TimeOfDay)
                                            .ThenBy(x => x.TimeStamp.Date)
                                                .ThenBy(x=> x.TimeStamp.Year)
                                                    .ToList();
                var d = new LastPictures();
                d.Name = s.Name;
                d.Pictures = s.Pictures.ToList(); //TODO mapper?
                if (count < d.Pictures.Count)
                {
                    d.Pictures.RemoveRange(count, d.Pictures.Count - count);
                }
                lastPictures.Add(d);
            }

            return lastPictures;
        }
    }
}
