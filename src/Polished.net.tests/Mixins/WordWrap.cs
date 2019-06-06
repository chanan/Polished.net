using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Mixins
{
    [TestClass]
    public class WordWrap
    {
        private readonly IMixins _mixins = new Polished.Mixins();

        [TestMethod]
        public void Default()
        {
            string actual = _mixins.WordWrap();
            string expected = "overflow-wrap:break-word;word-wrap:break-word;word-break:break-all;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BreakAll()
        {
            string actual = _mixins.WordWrap("break-all");
            string expected = "overflow-wrap:break-all;word-wrap:break-all;word-break:break-all;";
            Assert.AreEqual(expected, actual);
        }
    }
}
