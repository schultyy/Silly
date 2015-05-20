using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (runtime.HasCommand(command))
            {
                return ExecuteBuiltin(command, parameters);
            }
            return ExecuteSystemCommand(command, parameters);
        }

        private object ExecuteSystemCommand(string command, string[] parameters)
        {
            var processInfo = new ProcessStartInfo(command);
            processInfo.Arguments = String.Join(" ", parameters);
            processInfo.CreateNoWindow = true;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardInput = true;
            processInfo.RedirectStandardOutput = true;
            processInfo.UseShellExecute = false;
            processInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processInfo.WorkingDirectory = Environment.CurrentWorkingDirectory;
            var process = Process.Start(processInfo);
            return process.StandardOutput.ReadToEnd();
        }

        private object ExecuteBuiltin(string command, string[] parameters)
        {
            var result = runtime.Execute(command, Environment, parameters);
            if (result is Silly.Shell.Environment)
            {
                Environment = result as Silly.Shell.Environment;
            }
            return result;
        }
    }
}
