using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Mixins
{
    [TestClass]
    public class Ellipsis
    {
        private readonly IMixins _mixins = new Polished.Mixins();

        [TestMethod]
        public void NoParam()
        {
            string actual = _mixins.Ellipsis();
            string expected = "display:inline-block;max-width:100%;overflow:hidden;text-overflow:ellipsis;white-space:nowrap;word-wrap:normal;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NoUnitParam()
        {
            string actual = _mixins.Ellipsis("300");
            string expected = "display:inline-block;max-width:300;overflow:hidden;text-overflow:ellipsis;white-space:nowrap;word-wrap:normal;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UnitParam()
        {
            string actual = _mixins.Ellipsis("300px");
            string expected = "display:inline-block;max-width:300px;overflow:hidden;text-overflow:ellipsis;white-space:nowrap;word-wrap:normal;";
            Assert.AreEqual(expected, actual);
        }
    }
}
