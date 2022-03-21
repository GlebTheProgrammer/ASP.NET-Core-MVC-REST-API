using AutoMapper;
using Commander.domain;
using Commander.DTOs;
using Commander.Interfaces;
using Commander.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
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
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var commandItem = repository.GetCommandById(id);

            if (commandItem != null)
                return Ok(mapper.Map<CommandReadDto>(commandItem));

            return NotFound();
        }

        //POST api/commands
        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = mapper.Map<Command>(commandCreateDto);
            repository.CreateCommand(commandModel);
            repository.SaveChanges();

            var commandReadDto = mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);
            //return Ok(commandReadDto);
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepository = repository.GetCommandById(id);
            if (commandModelFromRepository == null)
            {
                return NotFound();
            }

            // This mapper has already updated model from DB with our new commandUpdateDto
            // Source -> Target
            mapper.Map(commandUpdateDto, commandModelFromRepository);
            repository.UpdateCommand(commandModelFromRepository);

            repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDocument)
        {
            var commandModelFromRepository = repository.GetCommandById(id);
            if (commandModelFromRepository == null)
            {
                return NotFound();
            }

            var commantToPatch = mapper.Map<CommandUpdateDto>(commandModelFromRepository);
            patchDocument.ApplyTo(commantToPatch, ModelState);

            if (!TryValidateModel(commantToPatch))
            {
                return ValidationProblem(ModelState);
            }

            // Source -> Target
            mapper.Map(commantToPatch, commandModelFromRepository);
            repository.UpdateCommand(commandModelFromRepository);

            repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepository = repository.GetCommandById(id);
            if (commandModelFromRepository == null)
            {
                return NotFound();
            }

            repository.DeleteCommand(commandModelFromRepository);
            repository.SaveChanges();

            return NoContent();
        }
    }
}
