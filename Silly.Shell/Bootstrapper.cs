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
        public List<File> Files { get; private set; }

        public Bootstrapper()
        {
            Files = new List<File>();
        }

        public void GatherFiles()
        {
            Files = Directory.EnumerateFiles("Commands", "*.js")
                            .Select(filename => new File
                            {
                                Filename = Path.GetFileNameWithoutExtension(filename),
                                Content = System.IO.File.ReadAllText(filename)
                            })
                            .ToList();
        }
    }
}
