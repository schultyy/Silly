using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Silly.Shell.Test
{
    [TestClass]
    public class CommandParserTest
    {
        private CommandParser parser;

        [TestInitialize]
        public void Setup()
        {
            parser = new CommandParser();
        }

        [TestMethod]
        public void ParseChangeDirectory()
        {
            var results = parser.Parse("cd Documents");
            Assert.AreEqual(new[] { "cd", "Documents" }, results);
        }

        [TestMethod]
        public void ParsePwd()
        {
            var results = parser.Parse("pwd");
            Assert.AreEqual(new[] { "pwd" }, results);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RaiseExceptionIfCommandIsNull()
        {
            parser.Parse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RaiseExceptionIfCommandIsEmpty()
        {
            parser.Parse(string.Empty);
        }
    }
}
