using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Mixins
{
    [TestClass]
    public class HideText
    {
        private readonly IMixins _mixins = new Polished.Mixins();

        [TestMethod]
        public void Simple()
        {
            Assert.AreEqual("text-indent:101%;overflow:hidden;white-space:nowrap;", _mixins.HideText());
        }

        [TestMethod]
        public void Div()
        {
            string actual = $"div{{background-image:url(logo.png);{_mixins.HideText()}}}";
            string expected = "div{background-image:url(logo.png);text-indent:101%;overflow:hidden;white-space:nowrap;}";
            Assert.AreEqual(expected, actual);
        }
    }
}
