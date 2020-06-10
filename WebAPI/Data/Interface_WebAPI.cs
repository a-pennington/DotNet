using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Data
{
	public interface I_WebAPIRepo
	{
		IEnumerable<Command> GetAllCommands();
		Command GetCommandByID(int ID);
	}

}
