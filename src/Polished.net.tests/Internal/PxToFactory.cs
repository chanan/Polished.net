using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polished.Internal;
using System;

namespace Polished.Tests.Internal
{
    [TestClass]
    public class PxToFactory
    {
        private readonly InternalHelpers _internalHelpers = new InternalHelpers();

        [TestMethod]
        public void Convert16()
        {
            Func<string, string, string> em = _internalHelpers.PxToFactory("em");
            string actual = "height:" + em("16", null) + ";";
            string expected = "height:1em;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Convert16px()
        {
            Func<string, string, string> em = _internalHelpers.PxToFactory("em");
            string actual = "height:" + em("16px", null) + ";";
            string expected = "height:1em;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Convert18()
        {
            Func<string, string, string> em = _internalHelpers.PxToFactory("em");
            string actual = "height:" + em("18", null) + ";";
            string expected = "height:1.125em;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Convert18px()
        {
            Func<string, string, string> em = _internalHelpers.PxToFactory("em");
            string actual = "height:" + em("18px", null) + ";";
            string expected = "height:1.125em;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Convert16Base8()
        {
            Func<string, string, string> em = _internalHelpers.PxToFactory("em");
            string actual = "height:" + em("16px", "8") + ";";
            string expected = "height:2em;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Convert16pxBase8()
        {
            Func<string, string, string> em = _internalHelpers.PxToFactory("em");
            string actual = "height:" + em("16px", "8px") + ";";
            string expected = "height:2em;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FirstArgShouldBeIntOrPx()
        {
            Func<string, string, string> em = _internalHelpers.PxToFactory("em");
            Assert.ThrowsException<PolishedException>(
                () => em("16em", null)
            );
        }

        [TestMethod]
        public void SecondArgShouldBeIntOrPx()
        {
            Func<string, string, string> em = _internalHelpers.PxToFactory("em");
            Assert.ThrowsException<PolishedException>(
                () => em("16px", "16em")
            );
        }

        [TestMethod]
        public void FirstArgShouldBeNumber()
        {
            Func<string, string, string> em = _internalHelpers.PxToFactory("em");
            Assert.ThrowsException<PolishedException>(
                () => em("apx", null)
            );
        }

        [TestMethod]
        public void SecondArgShouldBeNumber()
        {
            Func<string, string, string> em = _internalHelpers.PxToFactory("em");
            Assert.ThrowsException<PolishedException>(
                () => em("16px", "apx")
            );
        }
    }
}
