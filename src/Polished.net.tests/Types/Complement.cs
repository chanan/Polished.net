using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Types
{
    [TestClass]
    public class Complement
    {
        [TestMethod]
        public void ReducedHex()
        {
            HslColor hsl = HslColor.Parse("#448").Complement();
            Assert.AreEqual("#884", hsl.ToString());
        }

        [TestMethod]
        public void Hex()
        {
            HslColor hsl = HslColor.Parse("#CCCD64").Complement();
            Assert.AreEqual("#6564cd", hsl.ToString());
        }

        [TestMethod]
        public void Hex8Bit()
        {
            HslColor hsl = HslColor.Parse("#6564CDB3").Complement();
            Assert.AreEqual("rgba(204,205,100,0.7)", hsl.ToString());
        }

        [TestMethod]
        public void Hex4Bit()
        {
            HslColor hsl = HslColor.Parse("#0f08").Complement();
            Assert.AreEqual("rgba(255,0,255,0.53)", hsl.ToString());
        }

        [TestMethod]
        public void Rgba()
        {
            HslColor hsl = HslColor.Parse("rgba(101,100,205,0.7)").Complement();
            Assert.AreEqual("rgba(204,205,100,0.7)", hsl.ToString());
        }
    }
}
