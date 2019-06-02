using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polished.Types;

namespace Polished.tests
{
    [TestClass]
    public class ParseHsl
    {
        [TestMethod]
        public void HexString()
        {
            var hsl = HslColor.Parse("#Ff43AE");
            Assert.AreEqual(325.8510638297872, hsl.Hue);
            Assert.AreEqual(0.6313725490196078, hsl.Lightness);
            Assert.AreEqual(1, hsl.Saturation);
        }

        [TestMethod]
        public void HexString8bit()
        {
            var hsl = HslColor.Parse("#Ff43AEA7");
            Assert.AreEqual(325.8510638297872, hsl.Hue);
            Assert.AreEqual(0.6313725490196078, hsl.Lightness);
            Assert.AreEqual(1, hsl.Saturation);
            Assert.AreEqual(0.65d, hsl.Alpha);
        }

        [TestMethod]
        public void HexString4bit()
        {
            var hsl = HslColor.Parse("#0f08");
            Assert.AreEqual(120, hsl.Hue);
            Assert.AreEqual(0.5d, hsl.Lightness);
            Assert.AreEqual(1, hsl.Saturation);
            Assert.AreEqual(0.53d, hsl.Alpha);
        }

        [TestMethod]
        public void HexStringReduced()
        {
            var hsl = HslColor.Parse("#45a");
            Assert.AreEqual(230, hsl.Hue);
            Assert.AreEqual(0.4666666666666667, hsl.Lightness);
            Assert.AreEqual(0.42857142857142855, hsl.Saturation);
        }

        [TestMethod]
        public void RgbaString()
        {
            var hsl = HslColor.Parse("rgba(174,67,255,0.6)");
            Assert.AreEqual(274.1489361702128d, hsl.Hue);
            Assert.AreEqual(0.6313725490196078d, hsl.Lightness);
            Assert.AreEqual(1, hsl.Saturation);
            Assert.AreEqual(0.6d, hsl.Alpha);
        }

        [TestMethod]
        public void RgbString()
        {
            var hsl = HslColor.Parse("rgb(174,67,255)");
            Assert.AreEqual(274.1489361702128d, hsl.Hue);
            Assert.AreEqual(0.6313725490196078d, hsl.Lightness);
            Assert.AreEqual(1, hsl.Saturation);
        }

        [TestMethod]
        public void HslString()
        {
            var hsl = HslColor.Parse("hsl(210,10%,4%)");
            Assert.AreEqual(210, hsl.Hue);
            Assert.AreEqual(0.0392156862745098d, hsl.Lightness);
            Assert.AreEqual(0.1, hsl.Saturation);
        }

        [TestMethod]
        public void HsldoubleString()
        {
            var hsl = HslColor.Parse("hsl(210.99,10%,4%)");
            Assert.AreEqual(210, hsl.Hue);
            Assert.AreEqual(0.0392156862745098d, hsl.Lightness);
            Assert.AreEqual(0.1, hsl.Saturation);
        }

        [TestMethod]
        public void HslaString()
        {
            var hsl = HslColor.Parse("hsla(210,10%,40%,0.75)");
            Assert.AreEqual(209.99999999999997d, hsl.Hue);
            Assert.AreEqual(0.4d, hsl.Lightness);
            Assert.AreEqual(0.09803921568627451, hsl.Saturation);
            Assert.AreEqual(0.75d, hsl.Alpha);
        }

        [TestMethod]
        public void HslaFloatString()
        {
            var hsl = HslColor.Parse("hsla(210.99,10%,40%,0.75)");
            Assert.AreEqual(209.99999999999997d, hsl.Hue);
            Assert.AreEqual(0.4d, hsl.Lightness);
            Assert.AreEqual(0.09803921568627451, hsl.Saturation);
            Assert.AreEqual(0.75d, hsl.Alpha);
        }
    }
}
