using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Shorthand
{
    [TestClass]
    public class BorderStyle
    {
        [TestMethod]
        public void OneArg()
        {
            string actual = Polished.Shorthand.BorderStyle("solid");
            string expected = "border-top-style:solid;border-right-style:solid;border-bottom-style:solid;border-left-style:solid;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TwoArgs()
        {
            string actual = Polished.Shorthand.BorderStyle("solid", "dashed");
            string expected = "border-top-style:solid;border-right-style:dashed;border-bottom-style:solid;border-left-style:dashed;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThreeArgs()
        {
            string actual = Polished.Shorthand.BorderStyle("solid", "dashed", "dotted");
            string expected = "border-top-style:solid;border-right-style:dashed;border-bottom-style:dotted;border-left-style:dashed;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FourArgs()
        {
            string actual = Polished.Shorthand.BorderStyle("solid", "dashed", "dotted", "double");
            string expected = "border-top-style:solid;border-right-style:dashed;border-bottom-style:dotted;border-left-style:double;";
            Assert.AreEqual(expected, actual);
        }
    }
}
