using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Types
{
    [TestClass]
    public class Luminance
    {
        [TestMethod]
        public void Hex()
        {
            RgbColor rgb = RgbColor.Parse("#444");
            Assert.AreEqual(0.058, rgb.GetLuminance());
        }

        [TestMethod]
        public void Hex8Bit()
        {
            RgbColor rgb = RgbColor.Parse("#6564CDB3");
            Assert.AreEqual(0.163, rgb.GetLuminance());
        }

        [TestMethod]
        public void Hex4Bit()
        {
            RgbColor rgb = RgbColor.Parse("#0f08");
            Assert.AreEqual(0.715, rgb.GetLuminance());
        }

        [TestMethod]
        public void Rgba()
        {
            RgbColor rgb = RgbColor.Parse("rgba(101,100,205,0.7)");
            Assert.AreEqual(0.163, rgb.GetLuminance());
        }

        [TestMethod]
        public void Rgb()
        {
            RgbColor rgb = RgbColor.Parse("rgb(204,205,100)");
            Assert.AreEqual(0.574, rgb.GetLuminance());
        }

        [TestMethod]
        public void Hsla()
        {
            RgbColor rgb = RgbColor.Parse("hsla(250, 100%, 50%, 0.2)");
            Assert.AreEqual(0.077, rgb.GetLuminance());
        }

        [TestMethod]
        public void Hsl()
        {
            RgbColor rgb = RgbColor.Parse("hsl(0, 100%, 50%)");
            Assert.AreEqual(0.213, rgb.GetLuminance());
        }

        [TestMethod]
        public void NamedColor()
        {
            RgbColor rgb = RgbColor.Parse("papayawhip");
            Assert.AreEqual(0.878, rgb.GetLuminance());
        }
    }
}
