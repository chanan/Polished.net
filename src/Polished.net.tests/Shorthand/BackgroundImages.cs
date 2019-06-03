using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Shorthand
{
    [TestClass]
    public class BackgroundImages
    {
        private readonly IShorthand _shorthand = new Polished.Shorthand();

        [TestMethod]
        public void SingleArg()
        {
            string actual = _shorthand.BackgroundImages("url(\"/image/background.jpg\")");
            string expected = "background-image: url(\"/image/background.jpg\");";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiArg()
        {
            string actual = _shorthand.BackgroundImages("url(\"/image/background.jpg\")", "linear-gradient(red, green)");
            string expected = "background-image: url(\"/image/background.jpg\"), linear-gradient(red, green);";
            Assert.AreEqual(expected, actual);
        }
    }
}
