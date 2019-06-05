using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Mixins
{
    [TestClass]
    public class HiDPI
    {
        private readonly IMixins _mixins = new Polished.Mixins();

        [TestMethod]
        public void NoParam()
        {
            string actual = $"{_mixins.HiDPI()}{{width:200px;}}";
            string expected = "@media only screen and (-webkit-min-device-pixel-ratio: 1.3),only screen and (min--moz-device-pixel-ratio: 1.3),only screen and (-o-min-device-pixel-ratio: 1.3/1),only screen and (min-resolution: 125dpi),only screen and (min-resolution: 1.3dppx){width:200px;}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OneParam()
        {
            string actual = $"{_mixins.HiDPI(1.5)}{{width:200px;}}";
            string expected = "@media only screen and (-webkit-min-device-pixel-ratio: 1.5),only screen and (min--moz-device-pixel-ratio: 1.5),only screen and (-o-min-device-pixel-ratio: 1.5/1),only screen and (min-resolution: 144dpi),only screen and (min-resolution: 1.5dppx){width:200px;}";
            Assert.AreEqual(expected, actual);
        }
    }
}
