using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class MockWebAPIRepo : I_WebAPIRepo
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
    }
}
