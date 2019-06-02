using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polished.Types;

namespace Polished.tests
{
    [TestClass]
    public class AdjustHue
    {
        [TestMethod]
        public void ReducedHex()
        {
            var hsl = HslColor.Parse("#448").AdjustHue(20);
            Assert.AreEqual("#5b4488", hsl.ToString());
        }

        [TestMethod]
        public void Hex()
        {
            var hsl = HslColor.Parse("#CCCD64").AdjustHue(20);
            Assert.AreEqual("#a9cd64", hsl.ToString());
        }

        [TestMethod]
        public void Hex8Bit()
        {
            var hsl = HslColor.Parse("#6564CDB3").AdjustHue(20);
            Assert.AreEqual("rgba(136,100,205,0.7)", hsl.ToString());
        }

        [TestMethod]
        public void Hex4Bit()
        {
            var hsl = HslColor.Parse("#0f08").AdjustHue(20);
            Assert.AreEqual("rgba(0,255,85,0.53)", hsl.ToString());
        }

        [TestMethod]
        public void Rgba()
        {
            var hsl = HslColor.Parse("rgba(101,100,205,0.7)").AdjustHue(20);
            Assert.AreEqual("rgba(136,100,205,0.7)", hsl.ToString());
        }

        [TestMethod]
        public void NotOver360()
        {
            var hsl = HslColor.Parse("#448").AdjustHue(350);
            Assert.AreEqual("#444f88", hsl.ToString());
        }
    }
}
