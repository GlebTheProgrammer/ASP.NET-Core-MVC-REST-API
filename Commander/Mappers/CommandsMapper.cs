using AutoMapper;
using Commander.DTOs;
using Commander.Models;

namespace Commander.Mappers
{
    public class CommandsMapper : Profile
    {
        public CommandsMapper()
        {
            // Source -> Target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
        }
    }
}
