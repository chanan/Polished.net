using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polished.Tests.Shorthand
{
    [TestClass]
    public class Buttons
    {
        [TestMethod]
        public void Base()
        {
            var selectors = Polished.Shorthand.Buttons(Polished.Shorthand.InteractionState.Base);
            var actual = $"{selectors}:{{border-color:black;}}";
            var expected = "button, input[type=\"button\"], input[type=\"reset\"], input[type=\"submit\"]:{border-color:black;}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SingleState()
        {
            var selectors = Polished.Shorthand.Buttons(Polished.Shorthand.InteractionState.Active);
            var actual = $"{selectors}:{{border-color:black;}}";
            var expected = "button:active, input[type=\"button\"]:active, input[type=\"reset\"]:active, input[type=\"submit\"]:active:{border-color:black;}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BaseAndSingleState()
        {
            var selectors = Polished.Shorthand.Buttons(Polished.Shorthand.InteractionState.Base, Polished.Shorthand.InteractionState.Focus);
            var actual = $"{selectors}:{{border-color:black;}}";
            var expected = "button, input[type=\"button\"], input[type=\"reset\"], input[type=\"submit\"], button:focus, input[type=\"button\"]:focus, input[type=\"reset\"]:focus, input[type=\"submit\"]:focus:{border-color:black;}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiState()
        {
            var selectors = Polished.Shorthand.Buttons(Polished.Shorthand.InteractionState.Active, Polished.Shorthand.InteractionState.Focus);
            var actual = $"{selectors}:{{border-color:black;}}";
            var expected = "button:active, input[type=\"button\"]:active, input[type=\"reset\"]:active, input[type=\"submit\"]:active, button:focus, input[type=\"button\"]:focus, input[type=\"reset\"]:focus, input[type=\"submit\"]:focus:{border-color:black;}";
            Assert.AreEqual(expected, actual);
        }
    }
}
