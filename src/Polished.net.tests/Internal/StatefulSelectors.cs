using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polished.Internal;
using System.Collections.Generic;

namespace Polished.Tests.Internal
{
    [TestClass]
    public class StatefulSelectors
    {
        private readonly InternalHelpers _internalHelpers = new InternalHelpers();
        private readonly List<string> _mockStateMap = new List<string> { null, ":before", ":after" };

        private string MockTemplate(string pseudoSelector)
        {
            return $@"section a{pseudoSelector},
              p a{pseudoSelector}";
        }

        [TestMethod]
        public void SingleState()
        {
            string selectors = _internalHelpers.StatefulSelectors(new List<string> { ":before" }, MockTemplate, _mockStateMap);
            string actual = $"{selectors}:{{content:hello}}";
            string expected = "section a:before, p a:before:{content:hello}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiState()
        {
            string selectors = _internalHelpers.StatefulSelectors(new List<string> { ":before", ":after" }, MockTemplate, _mockStateMap);
            string actual = $"{selectors}:{{content:hello}}";
            string expected = "section a:before, p a:before, section a:after, p a:after:{content:hello}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SingleStateWithBase()
        {
            string selectors = _internalHelpers.StatefulSelectors(new List<string> { null, ":after" }, MockTemplate, _mockStateMap);
            string actual = $"{selectors}:{{content:hello}}";
            string expected = "section a, p a, section a:after, p a:after:{content:hello}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SingleStateWithBaseNoStateMap()
        {
            string selectors = _internalHelpers.StatefulSelectors(new List<string> { null, ":after" }, MockTemplate, null);
            string actual = $"{selectors}:{{content:hello}}";
            string expected = "section a, p a, section a:after, p a:after:{content:hello}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThrowsWhenNotInStateMap()
        {
            Assert.ThrowsException<PolishedException>(
                () => _internalHelpers.StatefulSelectors(new List<string> { ":visited" }, MockTemplate, _mockStateMap)
            );
        }


        [TestMethod]
        public void ThrowsWhenNotInStateMapMulti()
        {
            Assert.ThrowsException<PolishedException>(
                () => _internalHelpers.StatefulSelectors(new List<string> { ":before", ":visited" }, MockTemplate, _mockStateMap)
            );
        }

        [TestMethod]
        public void ThrowsWhenNoTemplate()
        {
            Assert.ThrowsException<PolishedException>(
                () => _internalHelpers.StatefulSelectors(new List<string> { ":before" }, null, _mockStateMap)
            );
        }

    }
}
