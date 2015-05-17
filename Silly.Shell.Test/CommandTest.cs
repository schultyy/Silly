using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Silly.Shell.Test
{
    [TestClass]
    public class CommandTest
    {
        private Command command;

        [TestInitialize]
        public void Setup()
        {
            command = new Command("add", "3 + 2");
        }

        [TestMethod]
        public void ExecuteReturnsResult()
        {
            Assert.AreEqual(5, command.Execute(null, new Environment("")));
        }
    }
}
