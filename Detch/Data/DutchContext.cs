using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreatVTwo.Data
{
    public class DutchContext:DbContext
    {
        public DutchContext(DbContextOptions<DutchContext> options):base(options)
        {

        }

        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
    }
}
