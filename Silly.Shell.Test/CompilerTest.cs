using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Silly.Shell.Test
{
    [TestClass]
    public class CompilerTest
    {
        private string testScript = @"
            class Student {
                fullname : string;
                constructor(public firstname, public middleinitial, public lastname) {
                    this.fullname = firstname + '' + middleinitial + '' + lastname;
                }
            }
            ";
        private Compiler compiler;

        [TestInitialize]
        public void Setup()
        {
            compiler = new Compiler();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RaiseExceptionIfScriptIsNull()
        {
            compiler.Compile(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RaiseExceptionIfScriptIsEmpty()
        {
            compiler.Compile(string.Empty);
        }

        [TestMethod]
        public void CompileTestScriptResultIsNotEmpty()
        {
            Assert.IsNotNull(compiler.Compile(testScript));
        }
    }
}
