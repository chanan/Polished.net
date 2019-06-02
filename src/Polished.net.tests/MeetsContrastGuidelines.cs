using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polished.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polished.tests
{
    [TestClass]
    public class MeetsContrastGuidelines
    {
        [TestMethod]
        public void Hex()
        {
            var rgb1 = RgbColor.Parse("#444");
            var rgb2 = RgbColor.Parse("#fff");
            var expected = new ContrastScore { AA = true, AALarge = true, AAA = true, AAALarge = true };
            var actual = rgb1.MeetsContrastGuidelines(rgb2);
            Assert.AreEqual(expected.AA, actual.AA);
            Assert.AreEqual(expected.AALarge, actual.AALarge);
            Assert.AreEqual(expected.AAA, actual.AAA);
            Assert.AreEqual(expected.AAALarge, actual.AAALarge);
        }

        [TestMethod]
        public void Hex8Bit()
        {
            var rgb1 = RgbColor.Parse("#6564CDB3");
            var rgb2 = RgbColor.Parse("#ffffff");
            var expected = new ContrastScore { AA = true, AALarge = true, AAA = false, AAALarge = true };
            var actual = rgb1.MeetsContrastGuidelines(rgb2);
            Assert.AreEqual(expected.AA, actual.AA);
            Assert.AreEqual(expected.AALarge, actual.AALarge);
            Assert.AreEqual(expected.AAA, actual.AAA);
            Assert.AreEqual(expected.AAALarge, actual.AAALarge);
        }

        [TestMethod]
        public void Hex4Bit()
        {
            var rgb1 = RgbColor.Parse("#0f08");
            var rgb2 = RgbColor.Parse("#000");
            var expected = new ContrastScore { AA = true, AALarge = true, AAA = true, AAALarge = true };
            var actual = rgb1.MeetsContrastGuidelines(rgb2);
            Assert.AreEqual(expected.AA, actual.AA);
            Assert.AreEqual(expected.AALarge, actual.AALarge);
            Assert.AreEqual(expected.AAA, actual.AAA);
            Assert.AreEqual(expected.AAALarge, actual.AAALarge);
        }

        [TestMethod]
        public void Rgba()
        {
            var rgb1 = RgbColor.Parse("rgba(101,100,205,0.7)");
            var rgb2 = RgbColor.Parse("rgba(0,0,0,1)");
            var expected = new ContrastScore { AA = false, AALarge = true, AAA = false, AAALarge = false };
            var actual = rgb1.MeetsContrastGuidelines(rgb2);
            Assert.AreEqual(expected.AA, actual.AA);
            Assert.AreEqual(expected.AALarge, actual.AALarge);
            Assert.AreEqual(expected.AAA, actual.AAA);
            Assert.AreEqual(expected.AAALarge, actual.AAALarge);
        }

        [TestMethod]
        public void Rgb()
        {
            var rgb1 = RgbColor.Parse("rgb(204,205,100)");
            var rgb2 = RgbColor.Parse("rgb(0,0,0)");
            var expected = new ContrastScore { AA = true, AALarge = true, AAA = true, AAALarge = true };
            var actual = rgb1.MeetsContrastGuidelines(rgb2);
            Assert.AreEqual(expected.AA, actual.AA);
            Assert.AreEqual(expected.AALarge, actual.AALarge);
            Assert.AreEqual(expected.AAA, actual.AAA);
            Assert.AreEqual(expected.AAALarge, actual.AAALarge);
        }

        [TestMethod]
        public void Hsla()
        {
            var rgb1 = RgbColor.Parse("hsla(250, 100%, 50%, 0.2)");
            var rgb2 = RgbColor.Parse("hsla(0, 100%, 100%, 1)");
            var expected = new ContrastScore { AA = true, AALarge = true, AAA = true, AAALarge = true };
            var actual = rgb1.MeetsContrastGuidelines(rgb2);
            Assert.AreEqual(expected.AA, actual.AA);
            Assert.AreEqual(expected.AALarge, actual.AALarge);
            Assert.AreEqual(expected.AAA, actual.AAA);
            Assert.AreEqual(expected.AAALarge, actual.AAALarge);
        }

        [TestMethod]
        public void Hsl()
        {
            var rgb1 = RgbColor.Parse("hsl(0, 100%, 50%)");
            var rgb2 = RgbColor.Parse("hsl(0, 100%, 100%)");
            var expected = new ContrastScore { AA = false, AALarge = true, AAA = false, AAALarge = false };
            var actual = rgb1.MeetsContrastGuidelines(rgb2);
            Assert.AreEqual(expected.AA, actual.AA);
            Assert.AreEqual(expected.AALarge, actual.AALarge);
            Assert.AreEqual(expected.AAA, actual.AAA);
            Assert.AreEqual(expected.AAALarge, actual.AAALarge);
        }

        [TestMethod]
        public void NamedColor()
        {
            var rgb1 = RgbColor.Parse("papayawhip");
            var rgb2 = RgbColor.Parse("black");
            var expected = new ContrastScore { AA = true, AALarge = true, AAA = true, AAALarge = true };
            var actual = rgb1.MeetsContrastGuidelines(rgb2);
            Assert.AreEqual(expected.AA, actual.AA);
            Assert.AreEqual(expected.AALarge, actual.AALarge);
            Assert.AreEqual(expected.AAA, actual.AAA);
            Assert.AreEqual(expected.AAALarge, actual.AAALarge);
        }
    }
}
