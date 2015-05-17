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
        }

        ~Command()
        {
            Dispose();
        }

        public object Execute(string[] args, Environment currentEnvironment)
        {
            return scriptEngine.Evaluate(this.script);
        }

        public void Dispose()
        {
            scriptEngine.Dispose();
        }
    }
}
