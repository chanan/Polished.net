using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Types
{
    [TestClass]
    public class Saturate
    {
        [TestMethod]
        public void ReducedHex()
        {
            HslColor hsl = HslColor.Parse("#444").Saturate(0.1d);
            Assert.AreEqual("#4b3d3d", hsl.ToString());
        }

        [TestMethod]
        public void Hex()
        {
            HslColor hsl = HslColor.Parse("#CCCD64").Saturate(0.2d);
            Assert.AreEqual("#e0e250", hsl.ToString());
        }

        [TestMethod]
        public void Hex4Bit()
        {
            HslColor hsl = HslColor.Parse("#0f08").Saturate(0.2d);
            Assert.AreEqual("rgba(0,255,0,0.53)", hsl.ToString());
        }

        [TestMethod]
        public void Hex8Bit()
        {
            HslColor hsl = HslColor.Parse("#6564CDB3").Saturate(0.2d);
            Assert.AreEqual("rgba(81,80,226,0.7)", hsl.ToString());
        }

        [TestMethod]
        public void Rgba()
        {
            HslColor hsl = HslColor.Parse("rgba(101,100,205,0.7)").Saturate(0.2d);
            Assert.AreEqual("rgba(81,80,226,0.7)", hsl.ToString());
        }

        [TestMethod]
        public void NotOver255()
        {
            HslColor hsl = HslColor.Parse("rgba(255,200,200,0.7)").Saturate(0.8d);
            Assert.AreEqual("rgba(255,200,200,0.7)", hsl.ToString());
        }
    }
}
