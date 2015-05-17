using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silly.Shell
{
    public class Bootstrapper
    {
        public List<string> Files { get; private set; }

        public Bootstrapper()
        {
            Files = new List<string>();
        }

        public void GatherFiles()
        {
            var foo = Directory.EnumerateFiles("Commands");
            Files = Directory.EnumerateFiles("Commands")
                .Select(filename => File.ReadAllText(filename))
                .ToList();
        }
    }
}
