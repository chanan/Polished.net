using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polished.Types;

namespace Polished.tests
{
    [TestClass]
    public class Transparentize
    {
        [TestMethod]
        public void TransparentizeFff()
        {
            var rgb = RgbColor.Parse("#fff").Transparentize(0.1);
            Assert.AreEqual("rgba(255,255,255,0.9)", rgb.ToString());
        }

        [TestMethod]
        public void Transparentize8Bit()
        {
            var rgb = RgbColor.Parse("#6564CDB3").Transparentize(0.1);
            Assert.AreEqual("rgba(101,100,205,0.6)", rgb.ToString());
        }

        [TestMethod]
        public void Transparentize4Bit()
        {
            var rgb = RgbColor.Parse("#0f08").Transparentize(0.1);
            Assert.AreEqual("rgba(0,255,0,0.43)", rgb.ToString());
        }

        [TestMethod]
        public void TransparentizeRgb()
        {
            var rgb = RgbColor.Parse("rgb(255, 0, 255)").Transparentize(0.1);
            Assert.AreEqual("rgba(255,0,255,0.9)", rgb.ToString());
        }

        [TestMethod]
        public void TransparentizeRgba01()
        {
            var rgb = RgbColor.Parse("rgba(101, 100, 205, .7)").Transparentize(0.1);
            Assert.AreEqual("rgba(101,100,205,0.6)", rgb.ToString());
        }

        [TestMethod]
        public void TransparentizeRgba03()
        {
            var rgb = RgbColor.Parse("rgba(255, 0, 0, .5)").Transparentize(0.3);
            Assert.AreEqual("rgba(255,0,0,0.2)", rgb.ToString());
        }

        [TestMethod]
        public void TransparentizeRgba05()
        {
            var rgb = RgbColor.Parse("rgba(255, 0, 0, .5)").Transparentize(0.5);
            Assert.AreEqual("rgba(255,0,0,0)", rgb.ToString());
        }

        [TestMethod]
        public void TransparentizeHsl()
        {
            var rgb = RgbColor.Parse("hsl(0, 0%, 100%)").Transparentize(0.2);
            Assert.AreEqual("rgba(255,255,255,0.8)", rgb.ToString());
        }

        [TestMethod]
        public void TransparentizeHsla()
        {
            var rgb = RgbColor.Parse("hsla(0, 0%, 100%, .8)").Transparentize(0.5);
            Assert.AreEqual("rgba(255,255,255,0.3)", rgb.ToString());
        }

        [TestMethod]
        public void TransparentizeNotBelow0()
        {
            var rgb = RgbColor.Parse("rgba(255, 0, 0, .2)").Transparentize(0.5);
            Assert.AreEqual("rgba(255,0,0,0)", rgb.ToString());
        }

        [TestMethod]
        public void TransparentizeNotOver1()
        {
            var rgb = RgbColor.Parse("rgba(255, 0, 0, .8)").Transparentize(-0.5);
            Assert.AreEqual("#f00", rgb.ToString());
        }
    }
}
