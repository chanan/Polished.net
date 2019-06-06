using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Mixins
{
    [TestClass]
    public class TimingFunctions
    {
        private readonly IMixins _mixins = new Polished.Mixins();

        [TestMethod]
        public void EaseInBack()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseInBack)};";
            string expected = "transition-timing-function:cubic-bezier(0.600, -0.280, 0.735, 0.045);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseInCirc()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseInCirc)};";
            string expected = "transition-timing-function:cubic-bezier(0.600,  0.040, 0.980, 0.335);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseInCubic()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseInCubic)};";
            string expected = "transition-timing-function:cubic-bezier(0.550,  0.055, 0.675, 0.190);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseInExpo()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseInExpo)};";
            string expected = "transition-timing-function:cubic-bezier(0.950,  0.050, 0.795, 0.035);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseInQuad()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseInQuad)};";
            string expected = "transition-timing-function:cubic-bezier(0.550,  0.085, 0.680, 0.530);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseInQuart()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseInQuart)};";
            string expected = "transition-timing-function:cubic-bezier(0.895,  0.030, 0.685, 0.220);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseInQuint()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseInQuint)};";
            string expected = "transition-timing-function:cubic-bezier(0.755,  0.050, 0.855, 0.060);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseInSine()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseInSine)};";
            string expected = "transition-timing-function:cubic-bezier(0.470,  0.000, 0.745, 0.715);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseOutBack()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseOutBack)};";
            string expected = "transition-timing-function:cubic-bezier(0.175,  0.885, 0.320, 1.275);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseOutCubic()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseOutCubic)};";
            string expected = "transition-timing-function:cubic-bezier(0.215,  0.610, 0.355, 1.000);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseOutCirc()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseOutCirc)};";
            string expected = "transition-timing-function:cubic-bezier(0.075,  0.820, 0.165, 1.000);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseOutExpo()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseOutExpo)};";
            string expected = "transition-timing-function:cubic-bezier(0.190,  1.000, 0.220, 1.000);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseOutQuad()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseOutQuad)};";
            string expected = "transition-timing-function:cubic-bezier(0.250,  0.460, 0.450, 0.940);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseOutQuart()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseOutQuart)};";
            string expected = "transition-timing-function:cubic-bezier(0.165,  0.840, 0.440, 1.000);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseOutQuint()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseOutQuint)};";
            string expected = "transition-timing-function:cubic-bezier(0.230,  1.000, 0.320, 1.000);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseOutSine()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseOutSine)};";
            string expected = "transition-timing-function:cubic-bezier(0.390,  0.575, 0.565, 1.000);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseInOutBack()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseInOutBack)};";
            string expected = "transition-timing-function:cubic-bezier(0.680, -0.550, 0.265, 1.550);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseInOutCirc()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseInOutCirc)};";
            string expected = "transition-timing-function:cubic-bezier(0.785,  0.135, 0.150, 0.860);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseInOutCubic()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseInOutCubic)};";
            string expected = "transition-timing-function:cubic-bezier(0.645,  0.045, 0.355, 1.000);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseInOutExpo()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseInOutExpo)};";
            string expected = "transition-timing-function:cubic-bezier(1.000,  0.000, 0.000, 1.000);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseInOutQuad()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseInOutQuad)};";
            string expected = "transition-timing-function:cubic-bezier(0.455,  0.030, 0.515, 0.955);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseInOutQuart()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseInOutQuart)};";
            string expected = "transition-timing-function:cubic-bezier(0.770,  0.000, 0.175, 1.000);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseInOutQuint()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseInOutQuint)};";
            string expected = "transition-timing-function:cubic-bezier(0.860,  0.000, 0.070, 1.000);";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EaseInOutSine()
        {
            string actual = $"transition-timing-function:{_mixins.TimingFunctions(TimingFunction.EaseInOutSine)};";
            string expected = "transition-timing-function:cubic-bezier(0.445,  0.050, 0.550, 0.950);";
            Assert.AreEqual(expected, actual);
        }
    }
}
