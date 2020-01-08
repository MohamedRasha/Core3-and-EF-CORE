using Microsoft.EntityFrameworkCore;
using OdeToFoodEntites;
using System;
using System.Collections.Generic;
using System.Linq;
namespace OdeToFood.Data
{
    public class SqlResturantData : IResturant
    {
        private readonly OdeToFoodDBContext dBContext;

        public SqlResturantData(OdeToFoodDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public Resturant Add(Resturant resturant)
        {
            dBContext.Resturants.Add(resturant);

            return resturant;
        }

        public int Commit()
        {
          return  dBContext.SaveChanges();
        }

        public Resturant Delete(int id)
        {
            var res = dBContext.Resturants.FirstOrDefault(c => c.Id == id);
            if (res!=null)
            {
                dBContext.Resturants.Remove(res);
            }
            return res;
        }

        public IEnumerable<Resturant> GetAll()
        {
            return dBContext.Resturants;
        }

        public Resturant GetById(int id)
        {
            return dBContext.Resturants.Find(id);
        }

        public IEnumerable<Resturant> GetByName(string Name)
        {
            if (!string.IsNullOrEmpty(Name))
             return dBContext.Resturants.Where(c => c.Name == Name);      
            else return null; 
        }

        public Resturant Update(Resturant updateResturant)
        {
            var entity = dBContext.Resturants.Attach(updateResturant);
            entity.State = EntityState.Modified;
            return updateResturant;

        }
    }
}
