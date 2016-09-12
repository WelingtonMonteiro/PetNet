using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATEA.DataAcess.Entity.Common
{
    public abstract class FATEATypeConfiguration<TEntity> : EntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        public FATEATypeConfiguration()
        {
            ConfigureTableName();
            ConfigureFields();
            ConfigurePrimaryKeys();
            ConfigureForeignKeys();
            ConfigureOthers();
        }

        public abstract void ConfigureTableName();
        public abstract void ConfigureFields();
        public abstract void ConfigurePrimaryKeys();
        public abstract void ConfigureForeignKeys();
        public abstract void ConfigureOthers();
    }
}
