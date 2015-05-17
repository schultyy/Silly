using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silly.Shell
{
    public class Compiler
    {
        public object Compile(string sourceFile)
        {
            using (var engine = new V8ScriptEngine())
            {
                engine.Script["sourcefile"] = sourceFile;
            }
            
            return null;
        }
    }
}
