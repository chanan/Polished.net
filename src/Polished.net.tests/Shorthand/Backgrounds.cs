﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Shorthand
{
    [TestClass]
    public class Backgrounds
    {
        [TestMethod]
        public void SingleArg()
        {
            string actual = Polished.Shorthand.Backgrounds("url(\"/image/background.jpg\")");
            string expected = "background: url(\"/image/background.jpg\");";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiArg()
        {
            string actual = Polished.Shorthand.Backgrounds("url(\"/image/background.jpg\")", "linear-gradient(red, green)", "center no-repeat");
            string expected = "background: url(\"/image/background.jpg\"), linear-gradient(red, green), center no-repeat;";
            Assert.AreEqual(expected, actual);
        }
    }
}
