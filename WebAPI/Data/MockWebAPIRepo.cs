using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class MockWebAPIRepo : I_WebAPIRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
			{
				new Command{ID=0, HowTo="DoSomething", Line="SomethingElse", Platform="Really?"},
				new Command{ID=1, HowTo="ABC123", Line="ncjdksnjk", Platform="oPAKXOPAXPPALOA?"},
				new Command{ID=2, HowTo="XYZ098", Line="blllihulbjku", Platform="12435463"},
				new Command{ID=3, HowTo="Hello", Line="World", Platform="Testing"}
			};

			return commands;
        }

        public Command GetCommandByID(int id)
        {
            return new Command{ID=0, HowTo="DoSomething", Line="SomethingElse", Platform="Really?"};
        }
    }
}
