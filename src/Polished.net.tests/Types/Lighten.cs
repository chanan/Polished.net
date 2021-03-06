﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Types
{
    [TestClass]
    public class Lighten
    {
        [TestMethod]
        public void ReducedHex()
        {
            HslColor hsl = HslColor.Parse("#444").Lighten(0.1d);
            Assert.AreEqual("#5e5e5e", hsl.ToString());
        }

        [TestMethod]
        public void Hex()
        {
            HslColor hsl = HslColor.Parse("#CCCD64").Lighten(0.2d);
            Assert.AreEqual("#e5e6b1", hsl.ToString());
        }

        [TestMethod]
        public void Hex4Bit()
        {
            HslColor hsl = HslColor.Parse("#0f08").Lighten(0.2d);
            Assert.AreEqual("rgba(102,255,102,0.53)", hsl.ToString());
        }

        [TestMethod]
        public void Hex8Bit()
        {
            HslColor hsl = HslColor.Parse("#6564CDB3").Lighten(0.2d);
            Assert.AreEqual("rgba(178,177,230,0.7)", hsl.ToString());
        }

        [TestMethod]
        public void Rgba()
        {
            HslColor hsl = HslColor.Parse("rgba(101,100,205,0.7)").Lighten(0.2d);
            Assert.AreEqual("rgba(178,177,230,0.7)", hsl.ToString());
        }

        [TestMethod]
        public void RgbaNotOver255()
        {
            HslColor hsl = HslColor.Parse("rgba(255,200,200,0.7)").Lighten(0.8d);
            Assert.AreEqual("rgba(255,255,255,0.7)", hsl.ToString());
        }
    }
}
