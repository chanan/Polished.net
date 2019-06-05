using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Mixins
{
    [TestClass]
    public class Between
    {
        private readonly IMixins _mixins = new Polished.Mixins();

        [TestMethod]
        public void FourParams()
        {
            string actual = _mixins.Between("20px", "100px", "400px", "1000px");
            string expected = "calc(-33.33px + 13.33vw)";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TwoParams()
        {
            string actual = _mixins.Between("20px", "100px");
            string expected = "calc(-9.09px + 9.09vw)";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThrowsWhenNoUnitForScreenSizes()
        {
            Assert.ThrowsException<PolishedException>(
                () => _mixins.Between("20px", "100px", "400", "1000")
            );
        }

        [TestMethod]
        public void ThrowsWhenUnitForScreenSizesDontMatch()
        {
            Assert.ThrowsException<PolishedException>(
                () => _mixins.Between("20px", "100px", "400em", "1000px")
            );
        }

        [TestMethod]
        public void ThrowsWhenNoUnitForToFromSizes()
        {
            Assert.ThrowsException<PolishedException>(
                () => _mixins.Between("20em", "100px", "400px", "1000px")
            );
        }

        [TestMethod]
        public void ThrowsWhenUnitForToFromDontMatch()
        {
            Assert.ThrowsException<PolishedException>(
                () => _mixins.Between("20px", "100px", "400", "1000")
            );
        }
    }
}
