using AutoMapper;
using MinecraftFarm.BussinessLogicLayer.DTOs;
using MinecraftFarm.ViewModels;

namespace MinecraftFarm.Mapping.Profiles
{
    public class PlayerResourcesProfile : Profile
    {
        public PlayerResourcesProfile()
        {
            CreateMap<PlayerResourceDto, PlayerResourceViewModel>()
                .ReverseMap();
        }
    }
}
