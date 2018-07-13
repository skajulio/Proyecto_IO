using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Y2K.Models
{
    public class Y2kContext:DbContext
    {
        public DbSet<City> City { get; set; }
        public DbSet<Weather> Weather { get; set; }
        public DbSet<Reservation> Reservacion { get; set; }
    }
}