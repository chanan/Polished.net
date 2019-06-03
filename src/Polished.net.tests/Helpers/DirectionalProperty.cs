using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Helpers
{
    [TestClass]
    public class DirectionalProperty
    {
        private readonly IHelpers _helpers = new Polished.Helpers();
        [TestMethod]
        public void OneArg()
        {
            string actual = _helpers.DirectionalProperty("border", "12px");
            string expected = "border-top:12px;border-right:12px;border-bottom:12px;border-left:12px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OneArgWithHyphen()
        {
            string actual = _helpers.DirectionalProperty("border-width", "12px");
            string expected = "border-top-width:12px;border-right-width:12px;border-bottom-width:12px;border-left-width:12px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OneArgNoProp()
        {
            string actual = _helpers.DirectionalProperty("", "12px");
            string expected = "top:12px;right:12px;bottom:12px;left:12px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TwoArgs()
        {
            string actual = _helpers.DirectionalProperty("border", "12px", "24px");
            string expected = "border-top:12px;border-right:24px;border-bottom:12px;border-left:24px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TwoArgsFirstNull()
        {
            string actual = _helpers.DirectionalProperty("border", null, "12px");
            string expected = "border-right:12px;border-left:12px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TwoArgsSecondNull()
        {
            string actual = _helpers.DirectionalProperty("border", "12px", null);
            string expected = "border-top:12px;border-bottom:12px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThreeArgs()
        {
            string actual = _helpers.DirectionalProperty("border", "12px", "24px", "36px");
            string expected = "border-top:12px;border-right:24px;border-bottom:36px;border-left:24px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThreeArgsFirstNull()
        {
            string actual = _helpers.DirectionalProperty("border", null, "24px", "36px");
            string expected = "border-right:24px;border-bottom:36px;border-left:24px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThreeArgsSecondNull()
        {
            string actual = _helpers.DirectionalProperty("border", "12px", null, "36px");
            string expected = "border-top:12px;border-bottom:36px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThreeArgsFourthNull()
        {
            string actual = _helpers.DirectionalProperty("border", "12px", "24px", null);
            string expected = "border-top:12px;border-right:24px;border-left:24px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FourArgs()
        {
            string actual = _helpers.DirectionalProperty("border", "12px", "24px", "36px", "48px");
            string expected = "border-top:12px;border-right:24px;border-bottom:36px;border-left:48px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FourArgsFirstNull()
        {
            string actual = _helpers.DirectionalProperty("border", null, "24px", "36px", "48px");
            string expected = "border-right:24px;border-bottom:36px;border-left:48px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FourArgsSecondNull()
        {
            string actual = _helpers.DirectionalProperty("border", "12px", null, "36px", "48px");
            string expected = "border-top:12px;border-bottom:36px;border-left:48px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FourArgsThirdNull()
        {
            string actual = _helpers.DirectionalProperty("border", "12px", "24px", null, "48px");
            string expected = "border-top:12px;border-right:24px;border-left:48px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FourArgsFourthNull()
        {
            string actual = _helpers.DirectionalProperty("border", "12px", "24px", "36px", null);
            string expected = "border-top:12px;border-right:24px;border-bottom:36px;";
            Assert.AreEqual(expected, actual);
        }
    }
}
