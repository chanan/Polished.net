using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polished.Types;

namespace Polished.tests
{
    [TestClass]
    public class Contrast
    {
        [TestMethod]
        public void Hex()
        {
            var rgb1 = RgbColor.Parse("#444");
            var rgb2 = RgbColor.Parse("#fff");
            Assert.AreEqual(9.72, rgb1.GetContrast(rgb2));
        }

        [TestMethod]
        public void Hex8Bit()
        {
            var rgb1 = RgbColor.Parse("#6564CDB3");
            var rgb2 = RgbColor.Parse("#ffffff");
            Assert.AreEqual(4.93, rgb1.GetContrast(rgb2));
        }

        [TestMethod]
        public void Hex4Bit()
        {
            var rgb1 = RgbColor.Parse("#0f08");
            var rgb2 = RgbColor.Parse("#000");
            Assert.AreEqual(15.3, rgb1.GetContrast(rgb2));
        }

        [TestMethod]
        public void Rgba()
        {
            var rgb1 = RgbColor.Parse("rgba(101,100,205,0.7)");
            var rgb2 = RgbColor.Parse("rgba(0,0,0,1)");
            Assert.AreEqual(4.26, rgb1.GetContrast(rgb2));
        }

        [TestMethod]
        public void Rgb()
        {
            var rgb1 = RgbColor.Parse("rgb(204,205,100)");
            var rgb2 = RgbColor.Parse("rgb(0,0,0)");
            Assert.AreEqual(12.48, rgb1.GetContrast(rgb2));
        }

        [TestMethod]
        public void Hsla()
        {
            var rgb1 = RgbColor.Parse("hsla(250, 100%, 50%, 0.2)");
            var rgb2 = RgbColor.Parse("hsla(0, 100%, 100%, 1)");
            Assert.AreEqual(8.27, rgb1.GetContrast(rgb2));
        }

        [TestMethod]
        public void Hsl()
        {
            var rgb1 = RgbColor.Parse("hsl(0, 100%, 50%)");
            var rgb2 = RgbColor.Parse("hsl(0, 100%, 100%)");
            Assert.AreEqual(3.99, rgb1.GetContrast(rgb2));
        }

        [TestMethod]
        public void NamedColor()
        {
            var rgb1 = RgbColor.Parse("papayawhip");
            var rgb2 = RgbColor.Parse("white");
            Assert.AreEqual(1.13, rgb1.GetContrast(rgb2));
        }
    }
}
