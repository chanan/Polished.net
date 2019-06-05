using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Polished.Tests.Mixins
{
    [TestClass]
    public class LinearGradient
    {
        private readonly IMixins _mixins = new Polished.Mixins();

        [TestMethod]
        public void TwoColorStops()
        {
            string actual = _mixins.LinearGradient(new LinearGradientConfiguration { ColorStops = new List<string> { "#fff", "#000" } });
            string expected = "background-color:#fff;background-image:linear-gradient(#fff, #000);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToDirection()
        {
            string actual = _mixins.LinearGradient(new List<string> { "#00FFFF 0%", "rgba(0, 0, 255, 0) 50%", "#0000FF 95%" }, null, "90deg");
            string expected = "background-color:#00FFFF;background-image:linear-gradient(90deg, #00FFFF 0%, rgba(0, 0, 255, 0) 50%, #0000FF 95%);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Fallback()
        {
            string actual = _mixins.LinearGradient(new List<string> { "#00FFFF 0%", "rgba(0, 0, 255, 0) 50%", "#0000FF 95%" }, "#FFF", "to top right");
            string expected = "background-color:#FFF;background-image:linear-gradient(to top right, #00FFFF 0%, rgba(0, 0, 255, 0) 50%, #0000FF 95%);";
            Assert.AreEqual(expected, actual);
        }
    }
}
