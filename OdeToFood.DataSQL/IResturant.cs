using OdeToFoodEntites;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace OdeToFood.Data
{
    public interface IResturant
    {
        IEnumerable<Resturant> GetAll();
        IEnumerable<Resturant> GetByName(string Name);
        Resturant GetById(int id);
        Resturant Update(Resturant updateResturant);
        int Commit();
        Resturant Add(Resturant resturant);
        Resturant Delete(int id);
    }
}
