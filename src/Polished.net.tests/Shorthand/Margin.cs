using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Shorthand
{
    [TestClass]
    public class Margin
    {
        private readonly IShorthand _shorthand = new Polished.Shorthand();

        [TestMethod]
        public void OneArg()
        {
            string actual = _shorthand.Margin("12px");
            string expected = "margin-top:12px;margin-right:12px;margin-bottom:12px;margin-left:12px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TwoArgs()
        {
            string actual = _shorthand.Margin("12px", "24px");
            string expected = "margin-top:12px;margin-right:24px;margin-bottom:12px;margin-left:24px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThreeArgs()
        {
            string actual = _shorthand.Margin("12px", "24px", "36px");
            string expected = "margin-top:12px;margin-right:24px;margin-bottom:36px;margin-left:24px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FourArgs()
        {
            string actual = _shorthand.Margin("12px", "24px", "36px", "48px");
            string expected = "margin-top:12px;margin-right:24px;margin-bottom:36px;margin-left:48px;";
            Assert.AreEqual(expected, actual);
        }
    }
}
