using Commander.DbConfiguration;
using Commander.Interfaces;
using Commander.Models;
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

        public IEnumerable<Command> GetAllCommands()
        {
            return context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return context.Commands.FirstOrDefault(c => c.Id == id);
        }
    }
}
