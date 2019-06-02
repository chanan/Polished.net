using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polished.Types;

namespace Polished.tests
{
    [TestClass]
    public class Desaturate
    {
        [TestMethod]
        public void ReducedHex()
        {
            var hsl = HslColor.Parse("#444").Desaturate(0.1d);
            Assert.AreEqual("#444", hsl.ToString());
        }

        [TestMethod]
        public void Hex()
        {
            var hsl = HslColor.Parse("#CCCD64").Desaturate(0.2d);
            Assert.AreEqual("#b8b878", hsl.ToString());
        }

        [TestMethod]
        public void Hex4Bit()
        {
            var hsl = HslColor.Parse("#0f08").Desaturate(0.2d);
            Assert.AreEqual("rgba(25,230,25,0.53)", hsl.ToString());
        }

        [TestMethod]
        public void Hex8Bit()
        {
            var hsl = HslColor.Parse("#6564CDB3").Desaturate(0.2d);
            Assert.AreEqual("rgba(121,120,184,0.7)", hsl.ToString());
        }

        [TestMethod]
        public void Rgba()
        {
            var hsl = HslColor.Parse("rgba(101,100,205,0.7)").Desaturate(0.2d);
            Assert.AreEqual("rgba(121,120,184,0.7)", hsl.ToString());
        }

        [TestMethod]
        public void NotUnder0()
        {
            var hsl = HslColor.Parse("rgba(40,20,10,0.7)").Desaturate(0.8d);
            Assert.AreEqual("rgba(25,25,25,0.7)", hsl.ToString());
        }
    }
}
