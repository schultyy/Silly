﻿using System;
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
            if (commandName == null)
                throw new ArgumentNullException("commandName");
            if (commandName == string.Empty)
                throw new ArgumentException("commandName");
            return null;
        }
    }
}
