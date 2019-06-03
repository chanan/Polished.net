using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Shorthand
{
    [TestClass]
    public class BorderRadius
    {
        private readonly IShorthand _shorthand = new Polished.Shorthand();

        [TestMethod]
        public void TopSide()
        {
            string actual = _shorthand.BorderRadius(Side.Top, "5px");
            string expected = "border-top-right-radius:5px;border-top-left-radius:5px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BottomSide()
        {
            string actual = _shorthand.BorderRadius(Side.Bottom, "5px");
            string expected = "border-bottom-right-radius:5px;border-bottom-left-radius:5px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LeftSide()
        {
            string actual = _shorthand.BorderRadius(Side.Left, "5px");
            string expected = "border-top-left-radius:5px;border-bottom-left-radius:5px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RightSide()
        {
            string actual = _shorthand.BorderRadius(Side.Right, "5px");
            string expected = "border-top-right-radius:5px;border-bottom-right-radius:5px;";
            Assert.AreEqual(expected, actual);
        }
    }
}
