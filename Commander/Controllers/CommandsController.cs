using AutoMapper;
using Commander.domain;
using Commander.DTOs;
using Commander.Interfaces;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepository repository;
        private readonly IMapper mapper;

        public CommandsController(ICommanderRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        // GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommand()
        {
            var commandItems = repository.GetAllCommands();

            return Ok(mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        // GET api/commands/5
        [HttpGet("{id}")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var commandItem = repository.GetCommandById(id);

            if (commandItem != null)
                return Ok(mapper.Map<CommandReadDto>(commandItem));

            return NotFound();
        }
    }
}
