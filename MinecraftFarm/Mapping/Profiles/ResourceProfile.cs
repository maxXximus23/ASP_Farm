using AutoMapper;
using MinecraftFarm.BussinessLogicLayer.DTOs;
using MinecraftFarm.ViewModels;

namespace MinecraftFarm.Mapping.Profiles
{
    public class ResourceProfile : Profile
    {
        private string defaultImgUrl = "https://lh3.googleusercontent.com/xRh1UsbatdDxkorrhNmMFpqINzq5R7Mpd-AWuc5b9Q6JxhBRLae8PE7RM1Zp1n29tUxzGdkCGOrTw38MQXmn7w=s400";
        public ResourceProfile()
        {
            CreateMap<ResourceDto, ResourceViewModel>()
                .ForMember(vm => vm.IconFileName, ex => ex.MapFrom(dto => string.IsNullOrEmpty(dto.IconFileName) ? defaultImgUrl : dto.IconFileName))
                .ReverseMap();
        }
    }
}
