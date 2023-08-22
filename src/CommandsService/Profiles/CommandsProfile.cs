using AutoMapper;

namespace CommandsService.Profiles
{
    public class Commandsprofile : Profile
    {
        public Commandsprofile()
        {
            // Source -> Target
            CreateMap<Models.Command, Dtos.CommandReadDto>();
            CreateMap<Dtos.CommandCreateDto, Models.Command>();
            CreateMap<Dtos.CommandReadDto, Models.Command>();

            CreateMap<Models.Platform, Dtos.PlatformReadDto>();
            CreateMap<Dtos.PlatformReadDto, Models.Platform>();
        }
    }
}