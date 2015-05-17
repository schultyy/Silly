using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Silly.Shell.Test
{
    [TestClass]
    public class BootstrapperTest
    {
        private Bootstrapper bootstrapper;

        [TestInitialize]
        public void Setup()
        {
            this.bootstrapper = new Bootstrapper();
        }
        
        [TestMethod]
        public void NewInstanceHasNoFilesYet()
        {
            var bootstrapper = new Bootstrapper();
            Assert.AreEqual(0, bootstrapper.Files.Count);
        }
        
        [TestMethod]
        public void GatherFiles()
        {
            bootstrapper.GatherFiles();
            Assert.AreEqual(1, bootstrapper.Files.Count);
        }
    }
}
