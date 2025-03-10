﻿using AutoMapper;
using KhumaloCraft.Services.ShoppingCartAPI.Models.Dto;
using KhumaloCraft.Services.ShoppingCartAPI.Models;

namespace KhumaloCraft.Services.ShoppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
