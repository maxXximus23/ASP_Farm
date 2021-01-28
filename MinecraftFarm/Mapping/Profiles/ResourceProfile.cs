using AutoMapper;
using MinecraftFarm.BussinessLogicLayer.DTOs;
using MinecraftFarm.ViewModels;

namespace MinecraftFarm.Mapping.Profiles
{
    public class ResourceProfile : Profile
    {
        public ResourceProfile()
        {
            CreateMap<ResourceDto, ResourceViewModel>()
                .ForMember(vm => vm.IconFileName, ex => ex.MapFrom(dto => string.IsNullOrEmpty(dto.IconFileName) ? "missing.png" : dto.IconFileName))
                .ReverseMap();
        }
    }
}
