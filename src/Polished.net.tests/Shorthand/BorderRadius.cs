using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Shorthand
{
    [TestClass]
    public class BorderRadius
    {
        [TestMethod]
        public void TopSide()
        {
            string actual = Polished.Shorthand.BorderRadius(Polished.Shorthand.Side.Top, "5px");
            string expected = "border-top-right-radius:5px;border-top-left-radius:5px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BottomSide()
        {
            string actual = Polished.Shorthand.BorderRadius(Polished.Shorthand.Side.Bottom, "5px");
            string expected = "border-bottom-right-radius:5px;border-bottom-left-radius:5px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LeftSide()
        {
            string actual = Polished.Shorthand.BorderRadius(Polished.Shorthand.Side.Left, "5px");
            string expected = "border-top-left-radius:5px;border-bottom-left-radius:5px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RightSide()
        {
            string actual = Polished.Shorthand.BorderRadius(Polished.Shorthand.Side.Right, "5px");
            string expected = "border-top-right-radius:5px;border-bottom-right-radius:5px;";
            Assert.AreEqual(expected, actual);
        }
    }
}
