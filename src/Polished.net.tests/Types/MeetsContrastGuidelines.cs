using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Types
{
    [TestClass]
    public class MeetsContrastGuidelines
    {
        [TestMethod]
        public void Hex()
        {
            RgbColor rgb1 = RgbColor.Parse("#444");
            RgbColor rgb2 = RgbColor.Parse("#fff");
            ContrastScore expected = new ContrastScore { AA = true, AALarge = true, AAA = true, AAALarge = true };
            ContrastScore actual = rgb1.MeetsContrastGuidelines(rgb2);
            Assert.AreEqual(expected.AA, actual.AA);
            Assert.AreEqual(expected.AALarge, actual.AALarge);
            Assert.AreEqual(expected.AAA, actual.AAA);
            Assert.AreEqual(expected.AAALarge, actual.AAALarge);
        }

        [TestMethod]
        public void Hex8Bit()
        {
            RgbColor rgb1 = RgbColor.Parse("#6564CDB3");
            RgbColor rgb2 = RgbColor.Parse("#ffffff");
            ContrastScore expected = new ContrastScore { AA = true, AALarge = true, AAA = false, AAALarge = true };
            ContrastScore actual = rgb1.MeetsContrastGuidelines(rgb2);
            Assert.AreEqual(expected.AA, actual.AA);
            Assert.AreEqual(expected.AALarge, actual.AALarge);
            Assert.AreEqual(expected.AAA, actual.AAA);
            Assert.AreEqual(expected.AAALarge, actual.AAALarge);
        }

        [TestMethod]
        public void Hex4Bit()
        {
            RgbColor rgb1 = RgbColor.Parse("#0f08");
            RgbColor rgb2 = RgbColor.Parse("#000");
            ContrastScore expected = new ContrastScore { AA = true, AALarge = true, AAA = true, AAALarge = true };
            ContrastScore actual = rgb1.MeetsContrastGuidelines(rgb2);
            Assert.AreEqual(expected.AA, actual.AA);
            Assert.AreEqual(expected.AALarge, actual.AALarge);
            Assert.AreEqual(expected.AAA, actual.AAA);
            Assert.AreEqual(expected.AAALarge, actual.AAALarge);
        }

        [TestMethod]
        public void Rgba()
        {
            RgbColor rgb1 = RgbColor.Parse("rgba(101,100,205,0.7)");
            RgbColor rgb2 = RgbColor.Parse("rgba(0,0,0,1)");
            ContrastScore expected = new ContrastScore { AA = false, AALarge = true, AAA = false, AAALarge = false };
            ContrastScore actual = rgb1.MeetsContrastGuidelines(rgb2);
            Assert.AreEqual(expected.AA, actual.AA);
            Assert.AreEqual(expected.AALarge, actual.AALarge);
            Assert.AreEqual(expected.AAA, actual.AAA);
            Assert.AreEqual(expected.AAALarge, actual.AAALarge);
        }

        [TestMethod]
        public void Rgb()
        {
            RgbColor rgb1 = RgbColor.Parse("rgb(204,205,100)");
            RgbColor rgb2 = RgbColor.Parse("rgb(0,0,0)");
            ContrastScore expected = new ContrastScore { AA = true, AALarge = true, AAA = true, AAALarge = true };
            ContrastScore actual = rgb1.MeetsContrastGuidelines(rgb2);
            Assert.AreEqual(expected.AA, actual.AA);
            Assert.AreEqual(expected.AALarge, actual.AALarge);
            Assert.AreEqual(expected.AAA, actual.AAA);
            Assert.AreEqual(expected.AAALarge, actual.AAALarge);
        }

        [TestMethod]
        public void Hsla()
        {
            RgbColor rgb1 = RgbColor.Parse("hsla(250, 100%, 50%, 0.2)");
            RgbColor rgb2 = RgbColor.Parse("hsla(0, 100%, 100%, 1)");
            ContrastScore expected = new ContrastScore { AA = true, AALarge = true, AAA = true, AAALarge = true };
            ContrastScore actual = rgb1.MeetsContrastGuidelines(rgb2);
            Assert.AreEqual(expected.AA, actual.AA);
            Assert.AreEqual(expected.AALarge, actual.AALarge);
            Assert.AreEqual(expected.AAA, actual.AAA);
            Assert.AreEqual(expected.AAALarge, actual.AAALarge);
        }

        [TestMethod]
        public void Hsl()
        {
            RgbColor rgb1 = RgbColor.Parse("hsl(0, 100%, 50%)");
            RgbColor rgb2 = RgbColor.Parse("hsl(0, 100%, 100%)");
            ContrastScore expected = new ContrastScore { AA = false, AALarge = true, AAA = false, AAALarge = false };
            ContrastScore actual = rgb1.MeetsContrastGuidelines(rgb2);
            Assert.AreEqual(expected.AA, actual.AA);
            Assert.AreEqual(expected.AALarge, actual.AALarge);
            Assert.AreEqual(expected.AAA, actual.AAA);
            Assert.AreEqual(expected.AAALarge, actual.AAALarge);
        }

        [TestMethod]
        public void NamedColor()
        {
            RgbColor rgb1 = RgbColor.Parse("papayawhip");
            RgbColor rgb2 = RgbColor.Parse("black");
            ContrastScore expected = new ContrastScore { AA = true, AALarge = true, AAA = true, AAALarge = true };
            ContrastScore actual = rgb1.MeetsContrastGuidelines(rgb2);
            Assert.AreEqual(expected.AA, actual.AA);
            Assert.AreEqual(expected.AALarge, actual.AALarge);
            Assert.AreEqual(expected.AAA, actual.AAA);
            Assert.AreEqual(expected.AAALarge, actual.AAALarge);
        }
    }
}
