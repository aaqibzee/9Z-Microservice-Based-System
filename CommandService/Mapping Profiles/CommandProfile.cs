using AutoMapper;
using commandService.Dtos;
using commandService.Models;

namespace commandService.Profiles
{
    public class commandsProfile : Profile
    {
        public commandsProfile()
        {
            //Source -> Target
            CreateMap<CommandCreateDto, Command>();
            CreateMap<Command, CommandReadDto>();
        }
    }
}