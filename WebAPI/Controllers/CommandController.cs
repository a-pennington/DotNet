using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("commands")]
    public class CommandController : ControllerBase
    {
        private readonly MockWebAPIRepo _repository = new MockWebAPIRepo();
        // GET commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(commandItems);
        }

        // GET commands/{id}
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandByID(int id)
        {
            var commandItem = _repository.GetCommandByID(id);
            return Ok(commandItem);
        }
    }
}