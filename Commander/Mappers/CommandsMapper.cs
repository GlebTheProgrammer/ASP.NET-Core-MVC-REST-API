using AutoMapper;
using Commander.DTOs;
using Commander.Models;

namespace Commander.Mappers
{
    public class CommandsMapper : Profile
    {
        public CommandsMapper()
        {
            CreateMap<Command, CommandReadDto>();
        }
    }
}
