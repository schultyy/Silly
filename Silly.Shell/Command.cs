using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ClearScript.V8;

namespace Silly.Shell
{
    public class Command : IDisposable
    {
        private V8ScriptEngine scriptEngine;

        private string script;

        public string Name { get; private set; }

        public Command(string name, string script)
        {
            this.Name = name;
            this.script = script;
            this.scriptEngine = new V8ScriptEngine();
            this.scriptEngine.AddHostType("Console", typeof(Console));
            this.scriptEngine.AddHostType("ClrString", typeof(string));
            this.scriptEngine.AddHostType("ClrList", typeof(List<>));
            this.scriptEngine.AddHostType("ClrArray", typeof(Array));
            this.scriptEngine.AddHostType("IEnumerable", typeof(IEnumerable<>));
            this.scriptEngine.AddHostType("File", typeof(System.IO.File));
            this.scriptEngine.AddHostType("Directory", typeof(System.IO.Directory));
        }

        ~Command()
        {
            Dispose();
        }

        public object Execute(string[] args, Environment currentEnvironment)
        {
            scriptEngine.Execute(this.script);
            scriptEngine.AddHostObject("env", currentEnvironment);
            return scriptEngine.Evaluate("call(env)");
        }

        public void Dispose()
        {
            scriptEngine.Dispose();
        }
    }
}
