using AutoMapper;
using MinecraftFarm.BussinessLogicLayer.DTOs;
using MinecraftFarm.ViewModels;

namespace MinecraftFarm.Mapping.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<PlayerDto, PlayerViewModel>()
                .ReverseMap();
        }
    }
}
