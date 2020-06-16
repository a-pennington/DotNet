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
    public class Person_Controller : ControllerBase
    {
        private readonly I_WebAPI_Repo _repository;
        private readonly IMapper _mapper;
        public Person_Controller(I_WebAPI_Repo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api
        [HttpGet]
        public ActionResult <IEnumerable<Person_Read_DTO>> GetAllPeople()
        {
            var peopleItem = _repository.GetAllPeople();
            return Ok(_mapper.Map<IEnumerable<Person_Read_DTO>>(peopleItem));
        }

        // GET api/{id}
        [HttpGet("{id}", Name="GetPersonByID")]
        public ActionResult <Person_Read_DTO> GetPersonByID(int id)
        {
            var personItem = _repository.GetPersonByID(id);
            if (personItem != null) 
            { 
                return Ok(_mapper.Map<Person_Read_DTO>(personItem)); 
            }
            return NotFound();
        }

        // POST api
        [HttpPost]
        public ActionResult <Person_Read_DTO> CreatePerson(Person_Create_DTO newPerson)
        {
            var personModel = _mapper.Map<Person>(newPerson);
            _repository.CreatePerson(personModel);
            _repository.SaveChanges();

            var personReadDTO = _mapper.Map<Person_Read_DTO>(personModel);

            return CreatedAtRoute(nameof(GetPersonByID), new {ID = personReadDTO.ID}, personReadDTO);
        }









    }
}