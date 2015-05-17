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
            return this.scriptEngine.Invoke(command, environment);
        }

        public void Dispose()
        {
            scriptEngine.Dispose();
        }
    }
}
