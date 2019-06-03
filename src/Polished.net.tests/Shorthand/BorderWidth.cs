using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Shorthand
{
    [TestClass]
    public class BorderWidth
    {
        private readonly IShorthand _shorthand = new Polished.Shorthand();

        [TestMethod]
        public void OneArg()
        {
            string actual = _shorthand.BorderWidth("12px");
            string expected = "border-top-width:12px;border-right-width:12px;border-bottom-width:12px;border-left-width:12px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TwoArgs()
        {
            string actual = _shorthand.BorderWidth("12px", "24px");
            string expected = "border-top-width:12px;border-right-width:24px;border-bottom-width:12px;border-left-width:24px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThreeArgs()
        {
            string actual = _shorthand.BorderWidth("12px", "24px", "36px");
            string expected = "border-top-width:12px;border-right-width:24px;border-bottom-width:36px;border-left-width:24px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FourArgs()
        {
            string actual = _shorthand.BorderWidth("12px", "24px", "36px", "48px");
            string expected = "border-top-width:12px;border-right-width:24px;border-bottom-width:36px;border-left-width:48px;";
            Assert.AreEqual(expected, actual);
        }
    }
}
