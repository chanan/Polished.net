using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Helpers
{
    [TestClass]
    public class StripUnit
    {
        private readonly IHelpers _helpers = new Polished.Helpers();

        [TestMethod]
        public void WholeNumber()
        {
            string actual = _helpers.StripUnit("1px");
            string expected = "1";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FloatNumber()
        {
            string actual = _helpers.StripUnit("1.5px");
            string expected = "1.5";
            Assert.AreEqual(expected, actual);
        }
    }
}
