using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using WebAPI.Data;
using WebAPI.Models;
using WebAPI.DTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/person")] // Defines the url from the port i.e. localhost:5000/api
    public class Person_Controller : ControllerBase
    {
        private readonly I_WebAPI_Repo _repository;
        private readonly IMapper _mapper;
        public Person_Controller(I_WebAPI_Repo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/person
        [HttpGet]
        public ActionResult <IEnumerable<Person_Read_DTO>> GetAllPeople()
        {
            var peopleItem = _repository.GetAllPeople();    // Gets all items in the DB
            return Ok(_mapper.Map<IEnumerable<Person_Read_DTO>>(peopleItem));   // Maps the items found to the data transfer object for return to the client
        }

        // GET api/person/{id}
        [HttpGet("{ID}", Name="GetPersonByID")]
        public ActionResult <Person_Read_DTO> GetPersonByID(int ID)
        {
            var personItem = _repository.GetPersonByID(ID);     // Gets the item at position ID
            if (personItem != null) 
            { 
                return Ok(_mapper.Map<Person_Read_DTO>(personItem));    // Maps the person to the data transfer object for return to the client
            }
            return NotFound();
        }

        // POST api/person
        [HttpPost]
        public ActionResult <Person_Read_DTO> CreatePerson(Person_Create_DTO newPerson)
        {
            var personModel = _mapper.Map<Person>(newPerson); // Maps the input information to a new 'person' object
            _repository.CreatePerson(personModel);            // Calls the repository implementation
            _repository.SaveChanges();                        // Applies the change

            var personReadDTO = _mapper.Map<Person_Read_DTO>(personModel);  // Maps the newly created person to the DTO for return to the client

            return CreatedAtRoute(nameof(GetPersonByID), new {ID = personReadDTO.ID}, personReadDTO);   
        }

        // PUT api/person/{id}
        [HttpPut("{ID}")]
        public ActionResult UpdatePerson(int ID, Person_Update_DTO newPerson)
        {
            var personFromRepo = _repository.GetPersonByID(ID); // Gets the person from the DB
            if (personFromRepo == null) { return NotFound(); }  // Exit if person not found

            _mapper.Map(newPerson, personFromRepo);   // Maps the new information to the found 
            _repository.UpdatePerson(personFromRepo); // This is unnecessary for this implementation, but good practice if the backend DB changes
            _repository.SaveChanges();                // Save the applied changes

            return NoContent();
        }

        // PATCH api/person/{id}
        [HttpPatch("{ID}")]
        public ActionResult PartialPersonUpdate(int ID, JsonPatchDocument<Person_Update_DTO> patchDoc)
        {
            var personFromRepo = _repository.GetPersonByID(ID); // Gets the person from the DB
            if (personFromRepo == null) { return NotFound(); }  // Exit if person not found

            var personToPatch = _mapper.Map<Person_Update_DTO>(personFromRepo);
            patchDoc.ApplyTo(personToPatch, ModelState);
            if (!TryValidateModel(personToPatch)) { return ValidationProblem(ModelState); }

            _mapper.Map(personToPatch, personFromRepo);   // Maps the patched information to the repo
            _repository.UpdatePerson(personFromRepo);     // This is unnecessary for this implementation, but good practice if the backend DB changes
            _repository.SaveChanges();                    // Save the applied changes

            return NoContent();
        }

        // DELETE api/person/{id}
        [HttpDelete("{ID}")]
        public ActionResult DeletePerson(int ID)
        {
            var personFromRepo = _repository.GetPersonByID(ID); // Gets the person from the DB
            if (personFromRepo == null) { return NotFound(); }  // Exit if person not found

            _repository.DeletePerson(personFromRepo);
            _repository.SaveChanges();

            return NoContent();
        } 

    }
}