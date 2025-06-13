using AutoMapper;
using DAL.DTOs.ProductDto;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductCreateDTO, Product>().ReverseMap();
        }
    }
}
