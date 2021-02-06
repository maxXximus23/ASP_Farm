using AutoMapper;
using MinecraftFarm.BussinessLogicLayer.DTOs;
using MinecraftFarm.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftFarm.BussinessLogicLayer.Mapping.Profiles
{
    class PlayerResourceProfile : Profile
    {
        public PlayerResourceProfile()
        {
            CreateMap<PlayerResource, PlayerResourceDto>()
                    .ReverseMap();
        }
    }
}
