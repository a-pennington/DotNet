using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
	public class Person
	{
		[Key]
		public int ID { get; set; }

		[Required]
		public string Firstname { get; set; }

		[Required]
		public string Surname { get; set; }

		[Required]
		public string Platform { get; set; }
	}
}
