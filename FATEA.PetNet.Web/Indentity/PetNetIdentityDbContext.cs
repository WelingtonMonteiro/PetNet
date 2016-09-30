using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATEA.PetNet.Web.Indentity
{
    public class PetNetIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public PetNetIdentityDbContext() : base("PetNetDbContext")
        {

        }
    }
}