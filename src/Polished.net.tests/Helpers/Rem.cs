using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Helpers
{
    [TestClass]
    public class Rem
    {
        public IHelpers _helpers = new Polished.Helpers();

        [TestMethod]
        public void ConvertToRems()
        {
            Assert.AreEqual("height:1rem;", $"height:{_helpers.Rem("16")};");
        }
    }
}
