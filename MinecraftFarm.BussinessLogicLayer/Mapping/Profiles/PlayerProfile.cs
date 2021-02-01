using AutoMapper;
using MinecraftFarm.BussinessLogicLayer.DTOs;
using MinecraftFarm.DataAccessLayer.Entities;

namespace MinecraftFarm.BussinessLogicLayer.Mapping.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerDto>();
            CreateMap<PlayerDto, Player>()
                .ForMember(p => p.Id, e => e.Ignore())
                .ForMember(p => p.Login, e => e.Ignore())
                .ForMember(p => p.Password, e => e.Ignore())
                .ForMember(p => p.IsBanned, e => e.Ignore());
        }
    }
}
