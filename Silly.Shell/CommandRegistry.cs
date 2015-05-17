using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silly.Shell
{
    public class CommandRegistry
    {
        private Dictionary<string, string> compiledCommands;

        public CommandRegistry(Dictionary<string, string> compiledCommands)
        {
            this.compiledCommands = compiledCommands;
        }

        public Command Resolve(string commandName)
        {
            throw new NotImplementedException();
        }
    }
}
