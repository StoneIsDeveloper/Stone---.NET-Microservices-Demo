using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            // Source => Target
            CreateMap<Platform,PlatformReadDto>();
            CreateMap<PlatformReadDto,Platform>();
            CreateMap<PlatformCreateDto,Platform>();
            CreateMap<PlatformUpdateDto,Platform>();

            CreateMap<PlatformReadDto,PlatformPublishedDto>();
        }
    }
}
