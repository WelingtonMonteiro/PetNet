using FATEA.DataAcess.Entity.Common;
using FATEA.PetNet.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATEA.PetNet.DataAccess.Entity.Configuration
{
    class AnimalTypeConfiguration : FATEATypeConfiguration<Animal>
    {
        public override void ConfigureFields()
        {
            Property(a => a.Id)
                .HasColumnName("ANI_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(a => a.Name)
                .HasColumnName("ANI_NAME")
                .HasMaxLength(50)
                .IsRequired();
            Property(a => a.Breed)
                .HasColumnName("ANI_BREED")
                .HasMaxLength(20)
                .IsRequired();

            Property(a => a.Age)
                .HasColumnName("ANI_AGE")
                .IsRequired();

            Property(a => a.Color)
                .HasColumnName("ANI_COLOR")
                .HasMaxLength(25)
                .IsRequired();

            Property(a => a.DateOfBirth)
                .HasColumnName("ANI_BIRTH_DATE")
                .IsRequired();

            Property(a => a.IsCastrated)
                .HasColumnName("ANI_IS_CASTRADE")
                .IsRequired();

            Property(a => a.Gender)
                .HasColumnName("ANI_GENDER")
                .IsRequired();
         
           
        }

        public override void ConfigureForeignKeys()
        {
            //throw new NotImplementedException();
        }

        public override void ConfigureOthers()
        {
            //throw new NotImplementedException();
        }

        public override void ConfigurePrimaryKeys()
        {
            HasKey(pk => pk.Id);
        }

        public override void ConfigureTableName()
        {
            ToTable("ANI_ANIMALS");
        }
    }
}
