using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polished.Tests.Mixins
{
    [TestClass]
    public class LinearGradient
    {
        IMixins _mixins = new Polished.Mixins();

        [TestMethod]
        public void TwoColorStops()
        {
            var actual = _mixins.LinearGradient(new LinearGradientConfiguration { ColorStops = new List<string> { "#fff", "#000" } });
            var expected = "background-color:#fff;background-image:linear-gradient(#fff, #000);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToDirection()
        {
            var actual = _mixins.LinearGradient(new List<string> { "#00FFFF 0%", "rgba(0, 0, 255, 0) 50%", "#0000FF 95%" }, null, "90deg");
            var expected = "background-color:#00FFFF;background-image:linear-gradient(90deg, #00FFFF 0%, rgba(0, 0, 255, 0) 50%, #0000FF 95%);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Fallback()
        {
            var actual = _mixins.LinearGradient(new List<string> { "#00FFFF 0%", "rgba(0, 0, 255, 0) 50%", "#0000FF 95%" }, "#FFF", "to top right");
            var expected = "background-color:#FFF;background-image:linear-gradient(to top right, #00FFFF 0%, rgba(0, 0, 255, 0) 50%, #0000FF 95%);";
            Assert.AreEqual(expected, actual);
        }
    }
}
