using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api")] // Defines the url from the port i.e. localhost:5000/api
    public class PersonController : ControllerBase
    {
        private readonly I_WebAPIRepo _repository;
        public PersonController(I_WebAPIRepo repository)
        {
            _repository = repository;
        }

        // GET api
        [HttpGet]
        public ActionResult <IEnumerable<Person>> GetAllPeople()
        {
            var peopleItem = _repository.GetAllPeople();
            return Ok(peopleItem);
        }

        // GET api/{id}
        [HttpGet("{id}")]
        public ActionResult <Person> GetPersonByID(int id)
        {
            var personItem = _repository.GetPersonByID(id);
            return Ok(personItem);
        }
    }
}