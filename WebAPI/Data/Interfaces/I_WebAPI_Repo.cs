using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Data
{
	public interface I_WebAPI_Repo
	{
		bool SaveChanges();

		// Used for 'Person'
		IEnumerable<Person> GetAllPeople();
		Person GetPersonByID(int ID);	
		void CreatePerson(Person person);
		void UpdatePerson(Person person);
		void DeletePerson(Person person);

		// Used for 'Matrix'

		IEnumerable<Matrix> GetAllMatrixStrings();
		Matrix GetMatrixByID(int id);
		void CreateMatrix(Matrix matrix);
		void DeleteMatrix(Matrix matrix);
	}

}
