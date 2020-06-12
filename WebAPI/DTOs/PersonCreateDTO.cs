using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
	public class PersonCreateDTO
	{
		[Required]
		public string Firstname { get; set; }

		[Required]
		public string Surname { get; set; }

		[Required]
		public string Platform { get; set; }
	}
}
