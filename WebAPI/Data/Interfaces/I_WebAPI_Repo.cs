using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Data
{
	public interface I_WebAPI_Repo
	{
		IEnumerable<Person> GetAllPeople();
		Person GetPersonByID(int ID);	
		void CreatePerson(Person person);
		bool SaveChanges();
		void UpdatePerson(Person person);
		void DeletePerson(Person person);
	}

}
