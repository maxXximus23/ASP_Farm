using AutoMapper;
using MinecraftFarm.BussinessLogicLayer.DTOs;
using MinecraftFarm.DataAccessLayer.Entities;

namespace MinecraftFarm.BussinessLogicLayer.Mapping.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerDto>().ReverseMap();
        }
    }
}
