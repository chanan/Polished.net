using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Types
{
    [TestClass]
    public class Darken
    {
        [TestMethod]
        public void ReducedHex()
        {
            HslColor hsl = HslColor.Parse("#444").Darken(0.2d);
            Assert.AreEqual("#111", hsl.ToString());
        }

        [TestMethod]
        public void Hex4Bit()
        {
            HslColor hsl = HslColor.Parse("#0f08").Darken(0.3d);
            Assert.AreEqual("rgba(0,102,0,0.53)", hsl.ToString());
        }

        [TestMethod]
        public void Hex8Bit()
        {
            HslColor hsl = HslColor.Parse("#6564CDB3").Darken(0.2d);
            Assert.AreEqual("rgba(51,50,153,0.7)", hsl.ToString());
        }

        [TestMethod]
        public void Rgba()
        {
            HslColor hsl = HslColor.Parse("rgba(101,100,205,0.7)").Darken(0.2d);
            Assert.AreEqual("rgba(51,50,153,0.7)", hsl.ToString());
        }

        [TestMethod]
        public void Rgba255()
        {
            HslColor hsl = HslColor.Parse("rgba(255,140,140,0.7)").Darken(0.1d);
            Assert.AreEqual("rgba(255,89,89,0.7)", hsl.ToString());
        }

        [TestMethod]
        public void NotUnder0()
        {
            HslColor hsl = HslColor.Parse("rgba(40,20,10,0.7)").Darken(0.8d);
            Assert.AreEqual("rgba(0,0,0,0.7)", hsl.ToString());
        }
    }
}
