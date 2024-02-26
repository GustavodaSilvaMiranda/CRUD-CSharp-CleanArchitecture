using AutoMapper;
using ProjChoc.Application.ViewModels;
using ProjChoc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjChoc.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() 
        {
            CreateMap<Product, ProductViewModel>(); 
        }
    }
}
