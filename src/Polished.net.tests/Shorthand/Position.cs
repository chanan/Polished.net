using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Shorthand
{
    [TestClass]
    public class Position
    {
        private readonly IShorthand _shorthand = new Polished.Shorthand();

        [TestMethod]
        public void OneArg()
        {
            string actual = _shorthand.Position(Polished.Position.Relative, "12px");
            string expected = "position:relative;top:12px;right:12px;bottom:12px;left:12px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TwoArgs()
        {
            string actual = _shorthand.Position(Polished.Position.Relative, "12px", "24px");
            string expected = "position:relative;top:12px;right:24px;bottom:12px;left:24px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThreeArgs()
        {
            string actual = _shorthand.Position(Polished.Position.Relative, "12px", "24px", "36px");
            string expected = "position:relative;top:12px;right:24px;bottom:36px;left:24px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FourArgs()
        {
            string actual = _shorthand.Position(Polished.Position.Relative, "12px", "24px", "36px", "48px");
            string expected = "position:relative;top:12px;right:24px;bottom:36px;left:48px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FourArgsWithoutPosition()
        {
            string actual = _shorthand.Position("12px", "24px", "36px", "48px");
            string expected = "top:12px;right:24px;bottom:36px;left:48px;";
            Assert.AreEqual(expected, actual);
        }
    }
}
