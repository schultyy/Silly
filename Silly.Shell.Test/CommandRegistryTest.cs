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

        private List<File> compiledCommands;

        [TestInitialize]
        public void Setup()
        {
            compiledCommands = new List<File> { new Silly.Shell.File { Filename = "ls", Content = "function ls() {}" } };
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

        [TestMethod]
        public void ResolveCommandByName()
        {
            Assert.IsInstanceOfType(registry.Resolve("ls"), typeof(Command));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RaiseErrorIfCommandNotFound()
        {
            registry.Resolve("cd");
        }
    }
}
