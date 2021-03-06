using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class Mock_WebAPI_Repo : I_WebAPI_Repo
    {
        public IEnumerable<Person> GetAllPeople()
        {
            var people = new List<Person>
			{
				new Person{ID=0, Firstname="Testing", Surname="User", Platform="This Works!"},
				new Person{ID=1, Firstname="Andrew", Surname="Pennington", Platform="Ubuntu"},
                new Person{ID=2, Firstname="Flo", Surname="Yapp", Platform="Mac"},
                new Person{ID=3, Firstname="Mark", Surname="Chatterton", Platform="Windows"}
			};

			return people;
        }

        public Person GetPersonByID(int id)
        {
            return new Person{ID=0, Firstname="Testing", Surname="User", Platform="This Works!"};
        }

        void I_WebAPI_Repo.CreatePerson(Person person)
        {
            throw new System.NotImplementedException();
        }

        bool I_WebAPI_Repo.SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        void I_WebAPI_Repo.UpdatePerson(Person person)
        {
            throw new System.NotImplementedException();
        }
        public void DeletePerson(Person person)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Matrix> I_WebAPI_Repo.GetAllMatrixStrings()
        {
            throw new System.NotImplementedException();
        }

        Matrix I_WebAPI_Repo.GetMatrixByID(int id)
        {
            throw new System.NotImplementedException();
        }

        void I_WebAPI_Repo.CreateMatrix(Matrix matrix)
        {
            throw new System.NotImplementedException();
        }

        void I_WebAPI_Repo.DeleteMatrix(Matrix matrix)
        {
            throw new System.NotImplementedException();
        }
    }
}
