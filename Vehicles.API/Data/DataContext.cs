using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data.Entities;

namespace Vehicles.API.Data
{
    public class DataContext: DbContext
    {
        //SE CREA LA CONEXION A LA BASE DE DATOS
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public DbSet<VehicleType> VehicleTypes { get; set; }

        //donde es la conexion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //se crea el indice
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<VehicleType>().HasIndex(x => x.Description).IsUnique();
        }
    }
}
