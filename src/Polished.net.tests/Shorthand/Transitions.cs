using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Polished.Tests.Shorthand
{
    [TestClass]
    public class Transitions
    {
        private readonly IShorthand _shorthand = new Polished.Shorthand();

        [TestMethod]
        public void OneParam()
        {
            string actual = _shorthand.Transitions("opacity 1.0s ease-in 0s");
            string expected = "transition: opacity 1.0s ease-in 0s;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiParams()
        {
            string actual = _shorthand.Transitions("opacity 1.0s ease-in 0s", "width 2.0s ease-in 2s");
            string expected = "transition: opacity 1.0s ease-in 0s, width 2.0s ease-in 2s;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PropertiesAndTransition()
        {
            string actual = _shorthand.Transitions(new List<string> { "color", "background-color" }, "2.0s ease-in 2s");
            string expected = "transition: color 2.0s ease-in 2s, background-color 2.0s ease-in 2s;";
            Assert.AreEqual(expected, actual);
        }
    }
}
