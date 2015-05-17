using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silly.Shell
{
    public class Compiler : IDisposable
    {
        private V8ScriptEngine scriptEngine;

        public Compiler()
        {
            this.scriptEngine = new V8ScriptEngine();
            scriptEngine.Execute(File.ReadAllText("typescriptServices.js"));
        }

        public object Compile(string sourceFile)
        {
            scriptEngine.Script["sourcefile"] = sourceFile;
            return scriptEngine.Evaluate("ts.transpile(sourcefile)");
        }

        public void Dispose()
        {
            this.scriptEngine.Dispose();
        }
    }
}
