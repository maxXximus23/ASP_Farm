using AutoMapper;
using MinecraftFarm.BussinessLogicLayer.DTOs;
using MinecraftFarm.DataAccessLayer.Entities;

namespace MinecraftFarm.BussinessLogicLayer.Mapping.Profiles
{
    class ResourceProfile : Profile
    {
        public ResourceProfile()
        {
            CreateMap<Resource, ResourceDto>().ReverseMap();
        }
    }
}
