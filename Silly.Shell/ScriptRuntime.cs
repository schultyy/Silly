using Microsoft.ClearScript.V8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silly.Shell
{
    public class ScriptRuntime : IDisposable
    {
        private V8ScriptEngine scriptEngine;
         
        public ScriptRuntime(List<File> commandFiles)
        {
            scriptEngine = new V8ScriptEngine();
            this.scriptEngine.AddHostType("Console", typeof(Console));
            this.scriptEngine.AddHostType("ClrString", typeof(string));
            this.scriptEngine.AddHostType("ClrList", typeof(List<>));
            this.scriptEngine.AddHostType("ClrArray", typeof(Array));
            this.scriptEngine.AddHostType("IEnumerable", typeof(IEnumerable<>));
            this.scriptEngine.AddHostType("File", typeof(System.IO.File));
            this.scriptEngine.AddHostType("Directory", typeof(System.IO.Directory));
            this.scriptEngine.AddHostType("DirectoryInfo", typeof(System.IO.DirectoryInfo));
            this.scriptEngine.AddHostType("Environment", typeof(Silly.Shell.Environment));
            this.scriptEngine.AddHostType("ClrEnvironment", typeof(System.Environment));
            this.LoadCommands(commandFiles);
        }

        private void LoadCommands(List<File> commandFiles)
        {
            foreach(var file in commandFiles)
            {
                this.scriptEngine.Execute(file.Content);
            }
        }

        public object Execute(string command, Environment environment, string[] args)
        {
            var parameters = new List<object>();
            parameters.Add(environment);
            if(args != null)
                parameters.AddRange(args);
            return this.scriptEngine.Invoke(command, parameters.ToArray());
        }

        public bool HasCommand(string command)
        {
            var result = scriptEngine.Evaluate(string.Format("typeof {0}", command)) as string;
            return result != "undefined";
        }

        public void Dispose()
        {
            scriptEngine.Dispose();
        }
    }
}
