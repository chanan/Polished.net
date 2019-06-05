using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Mixins
{
    [TestClass]
    public class Cover
    {
        private readonly IMixins _mixins = new Polished.Mixins();

        [TestMethod]
        public void NoParams()
        {
            string actual = _mixins.Cover();
            string expected = "position:absolute;top:0;right:0;bottom:0;left:0;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OneParam()
        {
            string actual = _mixins.Cover("100px");
            string expected = "position:absolute;top:100px;right:100px;bottom:100px;left:100px;";
            Assert.AreEqual(expected, actual);
        }
    }
}
