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
    [Route("matrix")]   // Defines the url from the port i.e. localhost:5000/matrix

    public class Matrix_Controller : ControllerBase
    {
        // Instantiates dependency injection
        private readonly I_WebAPI_Repo _repository; // Interface to repository
        private readonly IMapper _mapper;           // Mapper object
        public Matrix_Controller(I_WebAPI_Repo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET matrix
        [HttpGet]
        public ActionResult <IEnumerable<Matrix_Read_DTO>> GetAllMatrixStrings()
        {
            var matrixItem = _repository.GetAllMatrixStrings();    // Gets all items in the DB
            return Ok(_mapper.Map<IEnumerable<Matrix_Read_DTO>>(matrixItem));   // Maps the items found to the data transfer object for return to the client
        }

        // GET matrix/{ID}
        [HttpGet("{ID}", Name="GetMatrixByID")]
        public ActionResult <Matrix_Read_DTO> GetMatrixByID(int ID)
        {
            var matrixItem = _repository.GetMatrixByID(ID);     // Gets the item at position ID
            if (matrixItem != null) 
            { 
                return Ok(_mapper.Map<Matrix_Read_DTO>(matrixItem));    // Maps the object to the data transfer object for return to the client
            }
            return NotFound();
        }

        // POST matrix
        [HttpPost]
        public ActionResult <Matrix_Read_DTO> CreateMatrix(Matrix_Create_DTO newMatrix)
        {
            var matrixModel = _mapper.Map<Matrix>(newMatrix); // Maps the input information to a new 'matrix' object
            _repository.CreateMatrix(matrixModel);            // Calls the repository implementation
            _repository.SaveChanges();                        // Applies the change

            var matrixReadDTO = _mapper.Map<Matrix_Read_DTO>(matrixModel);  // Maps the newly created matrix to the DTO for return to the client

            return CreatedAtRoute(nameof(GetMatrixByID), new {ID = matrixReadDTO.ID}, matrixReadDTO);   
        }

        // DELETE matrix/{id}
        [HttpDelete("{ID}", Name="DeleteMatrixByID")]
        public ActionResult DeleteMatrix(int ID)
        {
            var matrixFromRepo = _repository.GetMatrixByID(ID); // Gets the matrix from the DB
            if (matrixFromRepo == null) { return NotFound(); }  // Exit if matrix not found

            _repository.DeleteMatrix(matrixFromRepo);
            _repository.SaveChanges();

            return NoContent();
        } 


        // GET matrix/string
        //[HttpGet("string")]



    }
}