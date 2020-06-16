using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class SQL_WebAPI_Repo : I_WebAPI_Repo
    {
        private readonly WebAPI_Context _context;
        public SQL_WebAPI_Repo(WebAPI_Context context)
        {
            _context = context;
        }
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

        bool I_WebAPI_Repo.SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
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

    }
}
