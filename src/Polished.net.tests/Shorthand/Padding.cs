using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Shorthand
{
    [TestClass]
    public class Padding
    {
        private readonly IShorthand _shorthand = new Polished.Shorthand();

        [TestMethod]
        public void OneArg()
        {
            string actual = _shorthand.Padding("12px");
            string expected = "padding-top:12px;padding-right:12px;padding-bottom:12px;padding-left:12px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TwoArgs()
        {
            string actual = _shorthand.Padding("12px", "24px");
            string expected = "padding-top:12px;padding-right:24px;padding-bottom:12px;padding-left:24px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThreeArgs()
        {
            string actual = _shorthand.Padding("12px", "24px", "36px");
            string expected = "padding-top:12px;padding-right:24px;padding-bottom:36px;padding-left:24px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FourArgs()
        {
            string actual = _shorthand.Padding("12px", "24px", "36px", "48px");
            string expected = "padding-top:12px;padding-right:24px;padding-bottom:36px;padding-left:48px;";
            Assert.AreEqual(expected, actual);
        }
    }
}
