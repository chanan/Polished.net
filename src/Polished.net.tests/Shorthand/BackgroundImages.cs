using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Shorthand
{
    [TestClass]
    public class BackgroundImages
    {
        [TestMethod]
        public void SingleArg()
        {
            string actual = Polished.Shorthand.BackgroundImages("url(\"/image/background.jpg\")");
            string expected = "background-image: url(\"/image/background.jpg\");";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiArg()
        {
            string actual = Polished.Shorthand.BackgroundImages("url(\"/image/background.jpg\")", "linear-gradient(red, green)");
            string expected = "background-image: url(\"/image/background.jpg\"), linear-gradient(red, green);";
            Assert.AreEqual(expected, actual);
        }
    }
}
