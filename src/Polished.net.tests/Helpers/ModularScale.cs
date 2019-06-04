using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Helpers
{
    [TestClass]
    public class ModularScale
    {
        private readonly IHelpers _helpers = new Polished.Helpers();

        [TestMethod]
        public void DefaultTo1EmPerfectFourth()
        {
            Assert.AreEqual("font-size:1em;", $"font-size:{_helpers.ModularScale(0)};");
            Assert.AreEqual("font-size:1.333em;", $"font-size:{_helpers.ModularScale(1)};");
            Assert.AreEqual("font-size:1.776889em;", $"font-size:{_helpers.ModularScale(2)};");
        }


        [TestMethod]
        public void AdjustBase()
        {
            Assert.AreEqual("font-size:2.666em;", $"font-size:{_helpers.ModularScale(1, "2em")};");
        }

        [TestMethod]
        public void ShouldAllowNumberAsBase()
        {
            Assert.AreEqual("font-size:2.666;", $"font-size:{_helpers.ModularScale(1, "2")};");
        }

        [TestMethod]
        public void ShouldAllowPresetRatio()
        {
            Assert.AreEqual("font-size:1.067em;", $"font-size:{_helpers.ModularScale(1, "1em", ModularScaleRatio.MinorSecond)};");
        }

        [TestMethod]
        public void ShouldThrowIfInvalidBase()
        {
            Assert.ThrowsException<PolishedException>(
                () => _helpers.ModularScale(1, "invalid", ModularScaleRatio.MinorSecond)
            );
        }
    }
}
