using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using WebAPI.Data;
using WebAPI.Models;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api")] // Defines the url from the port i.e. localhost:5000/api
    public class PersonController : ControllerBase
    {
        private readonly I_WebAPIRepo _repository;
        private readonly IMapper _mapper;
        public PersonController(I_WebAPIRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api
        [HttpGet]
        public ActionResult <IEnumerable<PersonReadDTO>> GetAllPeople()
        {
            var peopleItem = _repository.GetAllPeople();
            return Ok(_mapper.Map<IEnumerable<PersonReadDTO>>(peopleItem));
        }

        // GET api/{id}
        [HttpGet("{id}")]
        public ActionResult <PersonReadDTO> GetPersonByID(int id)
        {
            var personItem = _repository.GetPersonByID(id);
            if (personItem != null) 
            { 
                return Ok(_mapper.Map<PersonReadDTO>(personItem)); 
            }
            return NotFound();
        }
    }
}