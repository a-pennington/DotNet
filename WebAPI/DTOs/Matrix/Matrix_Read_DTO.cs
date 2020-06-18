using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
	public class Matrix_Read_DTO
	{
        public int ID {get; set; }
        
        public string matrixString { get; set; }

		public int precedingSpaces { get; set; }

		public int tailingSpaces { get; set; }
	}
}
