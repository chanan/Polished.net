using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polished.Types;

namespace Polished.tests
{
    [TestClass]
    public class Mix
    {
        [TestMethod]
        public void Mix2ColorsWith25()
        {
            var rgb = RgbColor.Parse("#f00");
            var rgb2 = RgbColor.Parse("#00f");
            var mix = rgb.Mix(rgb2, 0.25);
            Assert.AreEqual("#3f00bf", mix.ToString());
        }

        [TestMethod]
        public void Mix8Bit()
        {
            var rgb = RgbColor.Parse("#FF00007F");
            var rgb2 = RgbColor.Parse("#00f");
            var mix = rgb.Mix(rgb2, 0.5);
            Assert.AreEqual("rgba(63,0,191,0.75)", mix.ToString());
        }

        [TestMethod]
        public void Mix4Bit()
        {
            var rgb = RgbColor.Parse("#FF00007F");
            var rgb2 = RgbColor.Parse("#0f08");
            var mix = rgb.Mix(rgb2, 0.5);
            Assert.AreEqual("rgba(123,131,0,0.515)", mix.ToString());
        }

        [TestMethod]
        public void MixRgba()
        {
            var rgb = RgbColor.Parse("rgba(255, 0, 0, 0.5)");
            var rgb2 = RgbColor.Parse("#00f");
            var mix = rgb.Mix(rgb2, 0.5);
            Assert.AreEqual("rgba(63,0,191,0.75)", mix.ToString());
        }
    }
}
