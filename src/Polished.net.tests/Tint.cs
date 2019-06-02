using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polished.Types;

namespace Polished.tests
{
    [TestClass]
    public class Tint
    {
        [TestMethod]
        public void Hex()
        {
            var rgb = RgbColor.Parse("#00f").Tint(0.25);
            Assert.AreEqual("#3f3fff", rgb.ToString());
        }

        [TestMethod]
        public void Hex8Bit()
        {
            var rgb = RgbColor.Parse("#000fffcc").Tint(0.25);
            Assert.AreEqual("rgba(85,95,255,0.95)", rgb.ToString());
        }

        [TestMethod]
        public void Hex4Bit()
        {
            var rgb = RgbColor.Parse("#0f08").Tint(0.25);
            Assert.AreEqual("rgba(122,255,122,0.8825000000000001)", rgb.ToString());
        }
    }
}
