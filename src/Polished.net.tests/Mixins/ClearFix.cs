using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Mixins
{
    [TestClass]
    public class ClearFix
    {
        private readonly IMixins _mixins = new Polished.Mixins();

        [TestMethod]
        public void NoParent()
        {
            string actual = _mixins.ClearFix();
            string expected = "&:after{clear:both;content:\"\";display:table;}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Div()
        {
            string actual = _mixins.ClearFix("div");
            string expected = "div:after{clear:both;content:\"\";display:table;}";
            Assert.AreEqual(expected, actual);
        }
    }
}
