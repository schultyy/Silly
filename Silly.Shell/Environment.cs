using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silly.Shell
{
    public class Environment
    {
        public string CurrentWorkingDirectory { get; private set; }

        public Environment(string cwd)
        {
            this.CurrentWorkingDirectory = cwd;
        }
    }
}
