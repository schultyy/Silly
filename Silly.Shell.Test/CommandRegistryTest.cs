using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silly.Shell.Test
{
    [TestClass]
    public class CommandRegistryTest
    {
        private CommandRegistry registry;

        private Dictionary<string, string> compiledCommands;

        [TestInitialize]
        public void Setup()
        {
            compiledCommands = new Dictionary<string, string>{
                { "ls", "function ls{}" }
            };
            registry = new CommandRegistry(compiledCommands);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RaiseExceptionIfCommandnameIsNull()
        {
            registry.Resolve(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RaiseExceptionIfCommandnameIsEmpty()
        {
            registry.Resolve(string.Empty);
        }
    }
}
