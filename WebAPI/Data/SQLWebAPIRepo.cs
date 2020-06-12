using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class SQLWebAPIRepo : I_WebAPIRepo
    {
        private readonly WebAPIContext _context;
        public SQLWebAPIRepo(WebAPIContext context)
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

        
    }
}
