using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProductAPI.Models;
using ProductAPI.Models.Dto;

namespace ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps(){
            var mappingConfig = new MapperConfiguration(config =>{
                config.CreateMap<Product, ProductDTO>();
                config.CreateMap<ProductDTO, Product>();
            });
            return mappingConfig;
        }
    }
}