using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
	public class Matrix
	{
		[Key]
		public int ID { get; set; }

		[Required]
		public string matrixString { get; set; }

		[Required]
		public int precedingSpaces { get; set; }

		[Required]
		public int tailingSpaces { get; set; }
	}
}
