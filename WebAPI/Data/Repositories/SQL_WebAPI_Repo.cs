using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class SQL_WebAPI_Repo : I_WebAPI_Repo
    {
        // Dependency Injection
        private readonly WebAPI_Context _context;
        public SQL_WebAPI_Repo(WebAPI_Context context)
        {
            _context = context;
        }

        // Saves any changes made to the DB

        bool I_WebAPI_Repo.SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        // Person implemented methods

        public IEnumerable<Person> GetAllPeople()
        {
            return _context.DbSetPerson.ToList();
        }

        public Person GetPersonByID(int id)
        {
            return _context.DbSetPerson.FirstOrDefault(p => p.ID == id);
        }

        void I_WebAPI_Repo.CreatePerson(Person person)
        {
            if (person == null) { throw new ArgumentNullException(nameof(person)); }
            _context.DbSetPerson.Add(person);
        }

        void I_WebAPI_Repo.UpdatePerson(Person person)
        {
            // Don't need to do anything
        }
        
        void I_WebAPI_Repo.DeletePerson(Person person)
        {
             if (person == null) { throw new ArgumentNullException(nameof(person)); }
            _context.DbSetPerson.Remove(person);
        }

        // Matrix Implemented Methods

        IEnumerable<Matrix> I_WebAPI_Repo.GetAllMatrixStrings()
        {
            return _context.DbSetMatrix.ToList();
        }

        public Matrix GetMatrixByID(int id)
        {
            return _context.DbSetMatrix.FirstOrDefault(p => p.ID == id);
        }

        void I_WebAPI_Repo.CreateMatrix(Matrix matrix)
        {
            if (matrix == null) { throw new ArgumentNullException(nameof(matrix)); }
            _context.DbSetMatrix.Add(matrix);
        }

        void I_WebAPI_Repo.DeleteMatrix(Matrix matrix)
        {
             if (matrix == null) { throw new ArgumentNullException(nameof(matrix)); }
            _context.DbSetMatrix.Remove(matrix);
        }
    }
}
