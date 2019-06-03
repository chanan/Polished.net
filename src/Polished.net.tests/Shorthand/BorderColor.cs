using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Shorthand
{
    [TestClass]
    public class BorderColor
    {
        [TestMethod]
        public void OneArg()
        {
            string actual = Polished.Shorthand.BorderColor("red");
            string expected = "border-top-color:red;border-right-color:red;border-bottom-color:red;border-left-color:red;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TwoArgs()
        {
            string actual = Polished.Shorthand.BorderColor("red", "blue");
            string expected = "border-top-color:red;border-right-color:blue;border-bottom-color:red;border-left-color:blue;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThreeArgs()
        {
            string actual = Polished.Shorthand.BorderColor("red", "blue", "green");
            string expected = "border-top-color:red;border-right-color:blue;border-bottom-color:green;border-left-color:blue;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FourArgs()
        {
            string actual = Polished.Shorthand.BorderColor("red", "blue", "green", "yellow");
            string expected = "border-top-color:red;border-right-color:blue;border-bottom-color:green;border-left-color:yellow;";
            Assert.AreEqual(expected, actual);
        }
    }
}
