using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Types
{
    [TestClass]
    public class Invert
    {
        [TestMethod]
        public void ReducedHex()
        {
            RgbColor hsl = RgbColor.Parse("#448").Invert();
            Assert.AreEqual("#bb7", hsl.ToString());
        }

        [TestMethod]
        public void Hex()
        {
            RgbColor hsl = RgbColor.Parse("#CCCD64").Invert();
            Assert.AreEqual("#33329b", hsl.ToString());
        }

        [TestMethod]
        public void Hex8Bit()
        {
            RgbColor hsl = RgbColor.Parse("#6564CDB3").Invert();
            Assert.AreEqual("rgba(154,155,50,0.7)", hsl.ToString());
        }

        [TestMethod]
        public void Hex4Bit()
        {
            RgbColor hsl = RgbColor.Parse("#0f08").Invert();
            Assert.AreEqual("rgba(255,0,255,0.53)", hsl.ToString());
        }

        [TestMethod]
        public void Rgba()
        {
            RgbColor hsl = RgbColor.Parse("rgba(101,100,205,0.7)").Invert();
            Assert.AreEqual("rgba(154,155,50,0.7)", hsl.ToString());
        }
    }
}