using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silly.Shell
{
    public class CommandParser
    {
        public CommandParser()
        {

        }

        public string[] Parse(string command)
        {
            if(command == null)
            {
                throw new ArgumentNullException("command");
            }
            if(command == string.Empty)
            {
                throw new ArgumentException("command");
            }

            if(command.Contains(" "))
            {
                return command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            return new[] { command };
        }
    }
}
