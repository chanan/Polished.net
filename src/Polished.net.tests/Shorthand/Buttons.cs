using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Shorthand
{
    [TestClass]
    public class Buttons
    {
        private readonly IShorthand _shorthand = new Polished.Shorthand();

        [TestMethod]
        public void Base()
        {
            string selectors = _shorthand.Buttons(InteractionState.Base);
            string actual = $"{selectors}:{{border-color:black;}}";
            string expected = "button, input[type=\"button\"], input[type=\"reset\"], input[type=\"submit\"]:{border-color:black;}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SingleState()
        {
            string selectors = _shorthand.Buttons(InteractionState.Active);
            string actual = $"{selectors}:{{border-color:black;}}";
            string expected = "button:active, input[type=\"button\"]:active, input[type=\"reset\"]:active, input[type=\"submit\"]:active:{border-color:black;}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BaseAndSingleState()
        {
            string selectors = _shorthand.Buttons(InteractionState.Base, InteractionState.Focus);
            string actual = $"{selectors}:{{border-color:black;}}";
            string expected = "button, input[type=\"button\"], input[type=\"reset\"], input[type=\"submit\"], button:focus, input[type=\"button\"]:focus, input[type=\"reset\"]:focus, input[type=\"submit\"]:focus:{border-color:black;}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiState()
        {
            string selectors = _shorthand.Buttons(InteractionState.Active, InteractionState.Focus);
            string actual = $"{selectors}:{{border-color:black;}}";
            string expected = "button:active, input[type=\"button\"]:active, input[type=\"reset\"]:active, input[type=\"submit\"]:active, button:focus, input[type=\"button\"]:focus, input[type=\"reset\"]:focus, input[type=\"submit\"]:focus:{border-color:black;}";
            Assert.AreEqual(expected, actual);
        }
    }
}
