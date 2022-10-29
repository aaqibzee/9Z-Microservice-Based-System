using System.Collections.Generic;
using commandService.Models;

namespace CommandService.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommand(int id);
        bool CreateCommand(Command command);
    }
}