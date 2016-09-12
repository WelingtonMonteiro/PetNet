using FATEA.PetNet.DataAccess.Entity.Context;
using FATEA.PetNet.Domain;
using FATEA.Repository.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATEA.PetNet.Repository
{
    public class AnimalRepository : EntityCrudRepository<Animal, long>
    {
        public AnimalRepository(PetNetDbContext context) : base(context)
        {

        }
    }
}
