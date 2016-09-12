using System;
using FATEA.PetNet.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FATEA.PetNet.DataAccess.Entity.Configuration;

namespace FATEA.PetNet.DataAccess.Entity.Context
{
    //decorator para conexao mysql
    //[DbConfigurationType(typeof (MySql.Data.Entity.MySqlEFConfiguration))]
   public class PetNetDbContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }

        public PetNetDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnimalTypeConfiguration());
        }
    }
}
