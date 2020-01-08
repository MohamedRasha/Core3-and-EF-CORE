using OdeToFoodCLib;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryResturantData : IResturant
    {
        List<Resturant> resturnats;
        public InMemoryResturantData() => resturnats = new List<Resturant>()
            {
                new Resturant{Id=1,Name="Rasha 1",Location="cairo" , Cuisine=CuisineType.Egyptian},
                new Resturant{Id=2,Name="Omar 2",Location="alex",Cuisine=CuisineType.italian},
                new Resturant{Id=3,Name="Mohamed 3",Location="giza",Cuisine=CuisineType.Libanon}
            };

        public Resturant Add(Resturant resturant)
        {
            resturnats.Add(resturant);

            resturant.Id = resturnats.Max(r => r.Id) + 1;
            return resturant;
        }

        public int Commit()
        {
            return 0;        }

        public Resturant Delete(int id)
        {
            Resturant res = resturnats.FirstOrDefault(i => i.Id == id);
            if (res!=null)
            {
                resturnats.Remove(res);

            }
            return res;
        }

        public IEnumerable<Resturant> GetAll()
        {
            return resturnats.OrderBy(c => c.Name);
        }

        public Resturant GetById(int id)
        {
            return resturnats.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Resturant> GetByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                return resturnats.Where(c => c.Name.ToLower() == name.ToLower());
            else return GetAll();
        }

        public Resturant Update(Resturant updateResturant)
        {
            Resturant resutrant = resturnats.SingleOrDefault(c => c.Id == updateResturant.Id);
            if (resutrant != null)
            {
                resutrant.Name = updateResturant.Name;
                resutrant.Cuisine = updateResturant.Cuisine;
                resutrant.Location = updateResturant.Location;
            }
            return resutrant;
        }
    }
}
