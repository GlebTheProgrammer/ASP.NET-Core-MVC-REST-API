using Commander.domain;
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

        public CommandsController(ICommanderRepository repository)
        {
            this.repository = repository;
        }

        // GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommand()
        {
            var commandItems = repository.GetAllCommands();

            return Ok(commandItems);
        }

        // GET api/commands/5
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id)
        {
            var commandItem = repository.GetCommandById(id);

            return Ok(commandItem);
        }
    }
}
