﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silly.Shell
{
    public class CommandRegistry
    {
        private Command[] compiledCommands;

        public CommandRegistry(Dictionary<string, string> compiledCommands)
        {
            this.compiledCommands = compiledCommands.Select((pair, v) => new Command(pair.Key, pair.Value))
                .ToArray();
        }

        public Command Resolve(string commandName)
        {
            if (commandName == null)
                throw new ArgumentNullException("commandName");
            if (commandName == string.Empty)
                throw new ArgumentException("commandName");

            var result = compiledCommands.FirstOrDefault(cmd => cmd.Name == commandName);
            if (result == null)
                throw new ArgumentException(string.Format("Invalid command {0}", commandName));
            return result;
        }
    }
}
