namespace WebAPI.DTOs
{
	public class Person_Read_DTO
	{
		public int ID { get; set; }

		public string Firstname { get; set; }

		public string Surname { get; set; }

//      Won't include the platform as it is "restricted"
//      public string Platform { get; set; }
	}
}
