using Microsoft.EntityFrameworkCore;
using OdeToFoodCLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
  public  class OdeToFoodDBContext:DbContext
    {
        public OdeToFoodDBContext( DbContextOptions<OdeToFoodDBContext> options):base (options)
        {

        }
        public DbSet<Resturant> Resturants { get; set; }
    }
}
 