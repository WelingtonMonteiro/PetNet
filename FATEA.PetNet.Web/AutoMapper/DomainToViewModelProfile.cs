using AutoMapper;
using FATEA.PetNet.Domain;
using FATEA.PetNet.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATEA.PetNet.Web.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        protected override void Configure()
        {
            //Animal
            Mapper.CreateMap<Animal, AnimalIndexViewModel>();
            Mapper.CreateMap<Animal, AnimalEditViewModel>();
        }
    }
}