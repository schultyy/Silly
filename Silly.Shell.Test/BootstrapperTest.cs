using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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

        [TestMethod]
        public void FilesContainFilename()
        {
            bootstrapper.GatherFiles();
            var first = bootstrapper.Files.First();

            Assert.AreEqual("ls", first.Filename);
            Assert.IsNotNull(first.Content);
        }
    }
}
