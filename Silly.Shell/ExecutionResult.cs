using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silly.Shell
{
    public class ExecutionResult
    {
        public string StandardOut { get; private set; }
        public string StandardError { get; private set; }

        public ExecutionResult(string stdout, string stderr)
        {
            this.StandardError = stderr;
            this.StandardOut = stdout;
        }
    }
}
