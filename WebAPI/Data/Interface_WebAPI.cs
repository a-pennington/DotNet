using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Data
{
	public interface I_WebAPI
	{
		IEnumerable<WebAPI> GetAllCommands();
		WebAPI GetCommandByID(int ID);
	}

}
