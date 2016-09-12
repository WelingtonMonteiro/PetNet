using AutoMapper;
using FATEA.PetNet.Web.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATEA.PetNet.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<ViewModelToDomain>();
                config.AddProfile<DomainToViewModelProfile>();
            });
        }
    }
}