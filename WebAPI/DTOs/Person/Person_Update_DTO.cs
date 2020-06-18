using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
	public class Person_Update_DTO : Person_Create_DTO
	{
        // As this is identical to 'Person_Create_DTO' no need to implement, simply inherit
        // Added seperate file in codebase for legibility

		//[Required]
		//public string Firstname { get; set; }

		//[Required]
		//public string Surname { get; set; }

		//[Required]
		//public string Platform { get; set; }
	}
}
