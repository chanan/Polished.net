using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polished.Types;

namespace Polished.tests
{
    [TestClass]
    public class Shade
    {
        [TestMethod]
        public void Hex()
        {
            var rgb = RgbColor.Parse("#00f").Shade(0.25);
            Assert.AreEqual("#0000bf", rgb.ToString());
        }

        [TestMethod]
        public void Hex8Bit()
        {
            var rgb = RgbColor.Parse("#000fffcc").Shade(0.25);
            Assert.AreEqual("rgba(0,10,170,0.95)", rgb.ToString());
        }

        [TestMethod]
        public void Hex4Bit()
        {
            var rgb = RgbColor.Parse("#0f08").Shade(0.25);
            Assert.AreEqual("rgba(0,132,0,0.8825000000000001)", rgb.ToString());
        }
    }
}
