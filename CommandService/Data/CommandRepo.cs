using System;
using System.Collections.Generic;
using System.Linq;
using commandService.Models;;

namespace CommandService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext dBContext;
        public CommandRepo(AppDbContext db)
        {
            dBContext = db;
        }

        public bool CreateCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            dBContext.Commands.Add(command);
            return SaveChanges();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return dBContext.Commands.AsEnumerable<Command>();
        }

        public Command GetCommand(int id)
        {
            return dBContext.Commands.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return dBContext.SaveChanges() > 0;
        }
    }
}