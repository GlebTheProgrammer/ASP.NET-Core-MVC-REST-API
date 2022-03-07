using Commander.DbConfiguration;
using Commander.Interfaces;
using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Commander.domain
{
    public class SqlCommanderRepository : ICommanderRepository
    {
        private readonly MyDbContext context;
        public SqlCommanderRepository(MyDbContext context)
        {
            this.context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            context.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            context.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return context.Commands.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
            //Nothing
        }
    }
}
