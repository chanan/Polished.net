using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Types
{
    [TestClass]
    public class Mix
    {
        [TestMethod]
        public void Mix2ColorsWith25()
        {
            RgbColor rgb = RgbColor.Parse("#f00");
            RgbColor rgb2 = RgbColor.Parse("#00f");
            RgbColor mix = rgb.Mix(rgb2, 0.25);
            Assert.AreEqual("#3f00bf", mix.ToString());
        }

        [TestMethod]
        public void Mix8Bit()
        {
            RgbColor rgb = RgbColor.Parse("#FF00007F");
            RgbColor rgb2 = RgbColor.Parse("#00f");
            RgbColor mix = rgb.Mix(rgb2, 0.5);
            Assert.AreEqual("rgba(63,0,191,0.75)", mix.ToString());
        }

        [TestMethod]
        public void Mix4Bit()
        {
            RgbColor rgb = RgbColor.Parse("#FF00007F");
            RgbColor rgb2 = RgbColor.Parse("#0f08");
            RgbColor mix = rgb.Mix(rgb2, 0.5);
            Assert.AreEqual("rgba(123,131,0,0.515)", mix.ToString());
        }

        [TestMethod]
        public void MixRgba()
        {
            RgbColor rgb = RgbColor.Parse("rgba(255, 0, 0, 0.5)");
            RgbColor rgb2 = RgbColor.Parse("#00f");
            RgbColor mix = rgb.Mix(rgb2, 0.5);
            Assert.AreEqual("rgba(63,0,191,0.75)", mix.ToString());
        }
    }
}
