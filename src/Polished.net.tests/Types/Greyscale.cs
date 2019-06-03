using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Types
{
    [TestClass]
    public class Greyscale
    {
        [TestMethod]
        public void ReducedHex()
        {
            HslColor hsl = HslColor.Parse("#444").Greyscale();
            Assert.AreEqual("#444", hsl.ToString());
        }

        [TestMethod]
        public void Hex()
        {
            HslColor hsl = HslColor.Parse("#CCCD64").Greyscale();
            Assert.AreEqual("#989898", hsl.ToString());
        }

        [TestMethod]
        public void Hex8Bit()
        {
            HslColor hsl = HslColor.Parse("#6564CDB3").Greyscale();
            Assert.AreEqual("rgba(152,152,152,0.7)", hsl.ToString());
        }

        [TestMethod]
        public void Hex4Bit()
        {
            HslColor hsl = HslColor.Parse("#0f08").Greyscale();
            Assert.AreEqual("rgba(128,128,128,0.53)", hsl.ToString());
        }

        [TestMethod]
        public void Rgba()
        {
            HslColor hsl = HslColor.Parse("rgba(101,100,205,0.7)").Greyscale();
            Assert.AreEqual("rgba(152,152,152,0.7)", hsl.ToString());
        }
    }
}
