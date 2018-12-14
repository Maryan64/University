using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiDriverApp.DataTypes
{
    public class DriverContext : DbContext
    {
        public DbSet<TaxiDriver> Drivers { get; set; }
        public DbSet<TaxiClient> Clients { get; set; }
        public DbSet<TaxiOrder> Orders { get; set; }
        public DriverContext() : base("DriverContext")
        {
          //  Database.EnsureCreated();
        }
    }
}
