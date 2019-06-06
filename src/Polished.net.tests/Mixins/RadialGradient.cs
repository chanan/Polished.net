using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Polished.Tests.Mixins
{
    [TestClass]
    public class RadialGradient
    {
        private readonly IMixins _mixins = new Polished.Mixins();

        [TestMethod]
        public void TwoColorStops()
        {
            string actual = _mixins.RadialGradient(new RadialGradientConfiguration { ColorStops = new List<string> { "#fff", "#000" } });
            string expected = "background-color:#fff;background-image:radial-gradient(#fff, #000);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExtentShapeAndPosition()
        {
            string actual = _mixins.RadialGradient(new RadialGradientConfiguration
            {
                ColorStops = new List<string> { "#00FFFF 0%", "rgba(0, 0, 255, 0) 50%", "#0000FF 95%" },
                Extent = "farthest-corner at 45px 45px",
                Position = "center",
                Shape = "ellipse"
            });
            string expected = "background-color:#00FFFF;background-image:radial-gradient(center ellipse farthest-corner at 45px 45px, #00FFFF 0%, rgba(0, 0, 255, 0) 50%, #0000FF 95%);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExtentAndShape()
        {
            string actual = _mixins.RadialGradient(new RadialGradientConfiguration
            {
                ColorStops = new List<string> { "#00FFFF 0%", "rgba(0, 0, 255, 0) 50%", "#0000FF 95%" },
                Extent = "farthest-corner at 45px 45px",
                Shape = "ellipse"
            });
            string expected = "background-color:#00FFFF;background-image:radial-gradient(ellipse farthest-corner at 45px 45px, #00FFFF 0%, rgba(0, 0, 255, 0) 50%, #0000FF 95%);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Extent()
        {
            string actual = _mixins.RadialGradient(new RadialGradientConfiguration
            {
                ColorStops = new List<string> { "#00FFFF 0%", "rgba(0, 0, 255, 0) 50%", "#0000FF 95%" },
                Extent = "farthest-corner at 45px 45px"
            });
            string expected = "background-color:#00FFFF;background-image:radial-gradient(farthest-corner at 45px 45px, #00FFFF 0%, rgba(0, 0, 255, 0) 50%, #0000FF 95%);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExtentAndFallback()
        {
            string actual = _mixins.RadialGradient(new RadialGradientConfiguration
            {
                ColorStops = new List<string> { "#00FFFF 0%", "rgba(0, 0, 255, 0) 50%", "#0000FF 95%" },
                Extent = "farthest-corner at 45px 45px",
                Fallback = "#FFF"
            });
            string expected = "background-color:#FFF;background-image:radial-gradient(farthest-corner at 45px 45px, #00FFFF 0%, rgba(0, 0, 255, 0) 50%, #0000FF 95%);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThrowsIfColorStopsAreNull()
        {
            Assert.ThrowsException<PolishedException>(
                () => _mixins.RadialGradient(null, null, null, null, null)
            );

        }

        [TestMethod]
        public void ThrowsIfColorStopsAreLessThan2()
        {
            Assert.ThrowsException<PolishedException>(
                () => _mixins.RadialGradient(new List<string> { "#fff" }, null, null, null, null)
            );
        }
    }
}
