using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Shorthand
{
    [TestClass]
    public class Border
    {
        [TestMethod]
        public void FullBorder()
        {
            string actual = Polished.Shorthand.Border("1px", "solid", "red");
            string expected = "border-width:1px;border-style:solid;border-color:red;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BorderSideAsString()
        {
            string actual = Polished.Shorthand.Border("top", "1px", "solid", "red");
            string expected = "border-top-width:1px;border-top-style:solid;border-top-color:red;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BorderSideAsEnum()
        {
            string actual = Polished.Shorthand.Border(Polished.Shorthand.Side.Top, "1px", "solid", "red");
            string expected = "border-top-width:1px;border-top-style:solid;border-top-color:red;";
            Assert.AreEqual(expected, actual);
        }
    }
}
