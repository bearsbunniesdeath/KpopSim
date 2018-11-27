using Microsoft.VisualStudio.TestTools.UnitTesting;
using KpopSimEngine.Helpers.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KpopSimEngineTests.HelperTests
{
    [TestClass]
    public class NameGeneratorTests
    {

        [TestMethod]
        public void TestInitialize()
        {
            NameGenerator.Initialize();

            Assert.IsTrue(NameGenerator.FemaleGivenNames.Count > 0);
        }

    }
}
