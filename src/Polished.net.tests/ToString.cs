using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polished.Types;

namespace Polished.tests
{
    [TestClass]
    public class ToString
    {
        [TestMethod]
        public void HslToColorString()
        {
            var hsl = new HslColor { Hue = 240, Saturation = 1, Lightness = 0.5d };
            Assert.AreEqual("#00f", hsl.ToString());
        }

        [TestMethod]
        public void HslaToColorString()
        {
            var hsla = new HslColor { Hue = 360, Saturation = 0.75d, Lightness = 0.4d, Alpha = 0.72d };
            Assert.AreEqual("rgba(179,25,25,0.72)", hsla.ToString());
        }

        [TestMethod]
        public void HslToColorString2()
        {
            var hsl = new HslColor { Hue = 360, Saturation = 0.75d, Lightness = 0.4d };
            Assert.AreEqual("#b31919", hsl.ToString());
        }

        [TestMethod]
        public void RgbToColorString()
        {
            var rgb = new RgbColor { Red = 255, Green = 205, Blue = 100 };
            Assert.AreEqual("#ffcd64", rgb.ToString());
        }

        [TestMethod]
        public void RgbaToColorString()
        {
            var rgba = new RgbColor { Red = 255, Green = 205, Blue = 100, Alpha = 0.72d };
            Assert.AreEqual("rgba(255,205,100,0.72)", rgba.ToString());
        }

        [TestMethod]
        public void RgbToColorString2()
        {
            var rgb = new RgbColor { Red = 255, Green = 255, Blue = 255 };
            Assert.AreEqual("#fff", rgb.ToString());
        }
    }
}
