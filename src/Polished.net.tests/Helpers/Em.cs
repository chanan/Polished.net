using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Helpers
{
    [TestClass]
    public class Em
    {
        private readonly IHelpers _helpers = new Polished.Helpers();

        [TestMethod]
        public void ConvertPixelsToEms()
        {
            string actual = $"height:{_helpers.Em("16")};";
            string expected = "height:1em;";
            Assert.AreEqual(expected, actual);
        }
    }
}
