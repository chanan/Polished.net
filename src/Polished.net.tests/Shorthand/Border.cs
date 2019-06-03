using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Shorthand
{
    [TestClass]
    public class Border
    {
        private readonly IShorthand _shorthand = new Polished.Shorthand();

        [TestMethod]
        public void FullBorder()
        {
            string actual = _shorthand.Border("1px", "solid", "red");
            string expected = "border-width:1px;border-style:solid;border-color:red;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BorderSideAsString()
        {
            string actual = _shorthand.Border("top", "1px", "solid", "red");
            string expected = "border-top-width:1px;border-top-style:solid;border-top-color:red;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BorderSideAsEnum()
        {
            string actual = _shorthand.Border(Side.Top, "1px", "solid", "red");
            string expected = "border-top-width:1px;border-top-style:solid;border-top-color:red;";
            Assert.AreEqual(expected, actual);
        }
    }
}
