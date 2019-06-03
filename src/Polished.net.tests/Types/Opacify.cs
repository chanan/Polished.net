using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Types
{
    [TestClass]
    public class Opacify
    {
        [TestMethod]
        public void OpacifyFff()
        {
            RgbColor rgb = RgbColor.Parse("#fff").Opacify(0.1);
            Assert.AreEqual("#fff", rgb.ToString());
        }

        [TestMethod]
        public void Opacify8Bit()
        {
            RgbColor rgb = RgbColor.Parse("#6564CDB3").Opacify(0.1);
            Assert.AreEqual("rgba(101,100,205,0.8)", rgb.ToString());
        }

        [TestMethod]
        public void Opacify4Bit()
        {
            RgbColor rgb = RgbColor.Parse("#0f08").Opacify(0.1);
            Assert.AreEqual("rgba(0,255,0,0.63)", rgb.ToString());
        }

        [TestMethod]
        public void OpacifyRgba01()
        {
            RgbColor rgb = RgbColor.Parse("rgba(101, 100, 205, 0.7)").Opacify(0.1);
            Assert.AreEqual("rgba(101,100,205,0.8)", rgb.ToString());
        }

        [TestMethod]
        public void OpacifyRgba05()
        {
            RgbColor rgb = RgbColor.Parse("rgba(255, 0, 0, .5)").Opacify(0.5);
            Assert.AreEqual("#f00", rgb.ToString());
        }

        [TestMethod]
        public void OpacifyHsl()
        {
            RgbColor rgb = RgbColor.Parse("hsl(0, 0%, 100%)").Opacify(0.2);
            Assert.AreEqual("#fff", rgb.ToString());
        }

        [TestMethod]
        public void OpacifyHsla()
        {
            RgbColor rgb = RgbColor.Parse("hsla(0, 0%, 100%, .3)").Opacify(0.5);
            Assert.AreEqual("rgba(255,255,255,0.8)", rgb.ToString());
        }


        [TestMethod]
        public void OpacifyNotBelow0()
        {
            RgbColor rgb = RgbColor.Parse("rgba(255, 0, 0, .2)").Opacify(-0.5);
            Assert.AreEqual("rgba(255,0,0,0)", rgb.ToString());
        }

        [TestMethod]
        public void OpacifyNotOver1()
        {
            RgbColor rgb = RgbColor.Parse("rgba(255, 0, 0, .8)").Opacify(0.5);
            Assert.AreEqual("#f00", rgb.ToString());
        }
    }
}
