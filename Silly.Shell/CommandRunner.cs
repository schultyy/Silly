using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silly.Shell
{
    public class CommandRunner
    {
        private ScriptRuntime runtime;

        public Environment Environment { get; private set; }

        public CommandRunner(string initialWorkingDirectory)
        {
            this.Environment = new Environment(initialWorkingDirectory);
            var bootstrapper = new Bootstrapper();
            bootstrapper.GatherFiles();
            this.runtime = new ScriptRuntime(bootstrapper.Files);
        }

        public object Execute(string command, string[] parameters)
        {
            var result = runtime.Execute(command, Environment, parameters);
            if(result is Silly.Shell.Environment)
            {
                Environment = result as Silly.Shell.Environment;
            }
            return result;
        }       
    }
}
