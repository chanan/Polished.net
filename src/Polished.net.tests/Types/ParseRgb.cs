using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Types
{
    [TestClass]
    public class ParseRgb
    {
        [TestMethod]
        public void ColorName()
        {
            RgbColor rgb = RgbColor.Parse("white");
            Assert.AreEqual(255, rgb.Red);
            Assert.AreEqual(255, rgb.Green);
            Assert.AreEqual(255, rgb.Blue);
        }

        [TestMethod]
        public void FromRgb()
        {
            RgbColor rgb = RgbColor.Parse("rgb(174, 67, 255)");
            Assert.AreEqual(174, rgb.Red);
            Assert.AreEqual(67, rgb.Green);
            Assert.AreEqual(255, rgb.Blue);
        }

        [TestMethod]
        public void FromRgba()
        {
            RgbColor rgb = RgbColor.Parse("rgba(174, 67, 255, 0.6)");
            Assert.AreEqual(174, rgb.Red);
            Assert.AreEqual(67, rgb.Green);
            Assert.AreEqual(255, rgb.Blue);
            Assert.AreEqual(0.6d, rgb.Alpha);
        }

        [TestMethod]
        public void FromHex()
        {
            RgbColor rgb = RgbColor.Parse("#Ff43AE");
            Assert.AreEqual(255, rgb.Red);
            Assert.AreEqual(67, rgb.Green);
            Assert.AreEqual(174, rgb.Blue);
        }

        [TestMethod]
        public void FromHex8Bit()
        {
            RgbColor rgb = RgbColor.Parse("#Ff43AEFF");
            Assert.AreEqual(255, rgb.Red);
            Assert.AreEqual(67, rgb.Green);
            Assert.AreEqual(174, rgb.Blue);
            Assert.AreEqual(1, rgb.Alpha);
        }

        [TestMethod]
        public void FromHex4Bit()
        {
            RgbColor rgb = RgbColor.Parse("#0f08");
            Assert.AreEqual(0, rgb.Red);
            Assert.AreEqual(255, rgb.Green);
            Assert.AreEqual(0, rgb.Blue);
            Assert.AreEqual(0.53d, rgb.Alpha);
        }

        [TestMethod]
        public void FromReducedHex()
        {
            RgbColor rgb = RgbColor.Parse("#45a");
            Assert.AreEqual(68, rgb.Red);
            Assert.AreEqual(85, rgb.Green);
            Assert.AreEqual(170, rgb.Blue);
        }

        [TestMethod]
        public void FromHsl()
        {
            RgbColor rgb = RgbColor.Parse("hsl(210,10%,4%)");
            Assert.AreEqual(9, rgb.Red);
            Assert.AreEqual(10, rgb.Green);
            Assert.AreEqual(11, rgb.Blue);
        }

        [TestMethod]
        public void FromHsla()
        {
            RgbColor rgb = RgbColor.Parse("hsla( 210 , 10% , 40% , 0.75 )");
            Assert.AreEqual(92, rgb.Red);
            Assert.AreEqual(102, rgb.Green);
            Assert.AreEqual(112, rgb.Blue);
            Assert.AreEqual(0.75d, rgb.Alpha);
        }

        [TestMethod]
        public void ThrowsExceptionWhenBadString()
        {
            Assert.ThrowsException<PolishedException>(() => RgbColor.Parse("Not a color string"));
        }
    }
}
