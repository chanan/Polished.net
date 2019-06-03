using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Types
{
    [TestClass]
    public class AdjustHue
    {
        [TestMethod]
        public void ReducedHex()
        {
            HslColor hsl = HslColor.Parse("#448").AdjustHue(20);
            Assert.AreEqual("#5b4488", hsl.ToString());
        }

        [TestMethod]
        public void Hex()
        {
            HslColor hsl = HslColor.Parse("#CCCD64").AdjustHue(20);
            Assert.AreEqual("#a9cd64", hsl.ToString());
        }

        [TestMethod]
        public void Hex8Bit()
        {
            HslColor hsl = HslColor.Parse("#6564CDB3").AdjustHue(20);
            Assert.AreEqual("rgba(136,100,205,0.7)", hsl.ToString());
        }

        [TestMethod]
        public void Hex4Bit()
        {
            HslColor hsl = HslColor.Parse("#0f08").AdjustHue(20);
            Assert.AreEqual("rgba(0,255,85,0.53)", hsl.ToString());
        }

        [TestMethod]
        public void Rgba()
        {
            HslColor hsl = HslColor.Parse("rgba(101,100,205,0.7)").AdjustHue(20);
            Assert.AreEqual("rgba(136,100,205,0.7)", hsl.ToString());
        }

        [TestMethod]
        public void NotOver360()
        {
            HslColor hsl = HslColor.Parse("#448").AdjustHue(350);
            Assert.AreEqual("#444f88", hsl.ToString());
        }
    }
}
