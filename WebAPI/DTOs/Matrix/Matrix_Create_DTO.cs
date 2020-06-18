using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
	public class Matrix_Create_DTO
	{
		[Required]
		public string matrixString { get; set; }

		[Required]
		public int precedingSpaces { get; set; }

		[Required]
		public int tailingSpaces { get; set; }
	}
}
