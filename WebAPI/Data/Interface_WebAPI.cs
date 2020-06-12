using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Data
{
	public interface I_WebAPIRepo
	{
		IEnumerable<Person> GetAllPeople();
		Person GetPersonByID(int ID);	
		void CreatePerson(Person person);
		bool SaveChanges();
	}

}
