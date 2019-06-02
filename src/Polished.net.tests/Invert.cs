using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polished.Types;

namespace Polished.tests
{
    [TestClass]
    public class Invert
    {
        [TestMethod]
        public void ReducedHex()
        {
            var hsl = RgbColor.Parse("#448").Invert();
            Assert.AreEqual("#bb7", hsl.ToString());
        }

        [TestMethod]
        public void Hex()
        {
            var hsl = RgbColor.Parse("#CCCD64").Invert();
            Assert.AreEqual("#33329b", hsl.ToString());
        }

        [TestMethod]
        public void Hex8Bit()
        {
            var hsl = RgbColor.Parse("#6564CDB3").Invert();
            Assert.AreEqual("rgba(154,155,50,0.7)", hsl.ToString());
        }

        [TestMethod]
        public void Hex4Bit()
        {
            var hsl = RgbColor.Parse("#0f08").Invert();
            Assert.AreEqual("rgba(255,0,255,0.53)", hsl.ToString());
        }

        [TestMethod]
        public void Rgba()
        {
            var hsl = RgbColor.Parse("rgba(101,100,205,0.7)").Invert();
            Assert.AreEqual("rgba(154,155,50,0.7)", hsl.ToString());
        }
    }
}