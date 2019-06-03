using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Types
{
    [TestClass]
    public class Transparentize
    {
        [TestMethod]
        public void TransparentizeFff()
        {
            RgbColor rgb = RgbColor.Parse("#fff").Transparentize(0.1);
            Assert.AreEqual("rgba(255,255,255,0.9)", rgb.ToString());
        }

        [TestMethod]
        public void Transparentize8Bit()
        {
            RgbColor rgb = RgbColor.Parse("#6564CDB3").Transparentize(0.1);
            Assert.AreEqual("rgba(101,100,205,0.6)", rgb.ToString());
        }

        [TestMethod]
        public void Transparentize4Bit()
        {
            RgbColor rgb = RgbColor.Parse("#0f08").Transparentize(0.1);
            Assert.AreEqual("rgba(0,255,0,0.43)", rgb.ToString());
        }

        [TestMethod]
        public void TransparentizeRgb()
        {
            RgbColor rgb = RgbColor.Parse("rgb(255, 0, 255)").Transparentize(0.1);
            Assert.AreEqual("rgba(255,0,255,0.9)", rgb.ToString());
        }

        [TestMethod]
        public void TransparentizeRgba01()
        {
            RgbColor rgb = RgbColor.Parse("rgba(101, 100, 205, .7)").Transparentize(0.1);
            Assert.AreEqual("rgba(101,100,205,0.6)", rgb.ToString());
        }

        [TestMethod]
        public void TransparentizeRgba03()
        {
            RgbColor rgb = RgbColor.Parse("rgba(255, 0, 0, .5)").Transparentize(0.3);
            Assert.AreEqual("rgba(255,0,0,0.2)", rgb.ToString());
        }

        [TestMethod]
        public void TransparentizeRgba05()
        {
            RgbColor rgb = RgbColor.Parse("rgba(255, 0, 0, .5)").Transparentize(0.5);
            Assert.AreEqual("rgba(255,0,0,0)", rgb.ToString());
        }

        [TestMethod]
        public void TransparentizeHsl()
        {
            RgbColor rgb = RgbColor.Parse("hsl(0, 0%, 100%)").Transparentize(0.2);
            Assert.AreEqual("rgba(255,255,255,0.8)", rgb.ToString());
        }

        [TestMethod]
        public void TransparentizeHsla()
        {
            RgbColor rgb = RgbColor.Parse("hsla(0, 0%, 100%, .8)").Transparentize(0.5);
            Assert.AreEqual("rgba(255,255,255,0.3)", rgb.ToString());
        }

        [TestMethod]
        public void TransparentizeNotBelow0()
        {
            RgbColor rgb = RgbColor.Parse("rgba(255, 0, 0, .2)").Transparentize(0.5);
            Assert.AreEqual("rgba(255,0,0,0)", rgb.ToString());
        }

        [TestMethod]
        public void TransparentizeNotOver1()
        {
            RgbColor rgb = RgbColor.Parse("rgba(255, 0, 0, .8)").Transparentize(-0.5);
            Assert.AreEqual("#f00", rgb.ToString());
        }
    }
}
