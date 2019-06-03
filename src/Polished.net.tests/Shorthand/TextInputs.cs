using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Shorthand
{
    [TestClass]
    public class TextInputs
    {
        private readonly IShorthand _shorthand = new Polished.Shorthand();

        [TestMethod]
        public void Base()
        {
            string selectors = _shorthand.TextInputs(InteractionState.Base);
            string actual = $"{selectors}:{{border-color:black;}}";
            string expected = "input[type=\"color\"], input[type=\"date\"], input[type=\"datetime\"], input[type=\"datetime-local\"], input[type=\"email\"], input[type=\"month\"], input[type=\"number\"], input[type=\"password\"], input[type=\"search\"]$, input[type=\"tel\"], input[type=\"text\"], input[type=\"time\"], input[type=\"url\"], input[type=\"week\"], input:not([type]), textarea:{border-color:black;}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SingleState()
        {
            string selectors = _shorthand.TextInputs(InteractionState.Active);
            string actual = $"{selectors}:{{border-color:black;}}";
            string expected = "input[type=\"color\"]:active, input[type=\"date\"]:active, input[type=\"datetime\"]:active, input[type=\"datetime-local\"]:active, input[type=\"email\"]:active, input[type=\"month\"]:active, input[type=\"number\"]:active, input[type=\"password\"]:active, input[type=\"search\"]$:active, input[type=\"tel\"]:active, input[type=\"text\"]:active, input[type=\"time\"]:active, input[type=\"url\"]:active, input[type=\"week\"]:active, input:not([type]):active, textarea:active:{border-color:black;}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BaseAndSingleState()
        {
            string selectors = _shorthand.TextInputs(InteractionState.Base, InteractionState.Focus);
            string actual = $"{selectors}:{{border-color:black;}}";
            string expected = "input[type=\"color\"], input[type=\"date\"], input[type=\"datetime\"], input[type=\"datetime-local\"], input[type=\"email\"], input[type=\"month\"], input[type=\"number\"], input[type=\"password\"], input[type=\"search\"]$, input[type=\"tel\"], input[type=\"text\"], input[type=\"time\"], input[type=\"url\"], input[type=\"week\"], input:not([type]), textarea, input[type=\"color\"]:focus, input[type=\"date\"]:focus, input[type=\"datetime\"]:focus, input[type=\"datetime-local\"]:focus, input[type=\"email\"]:focus, input[type=\"month\"]:focus, input[type=\"number\"]:focus, input[type=\"password\"]:focus, input[type=\"search\"]$:focus, input[type=\"tel\"]:focus, input[type=\"text\"]:focus, input[type=\"time\"]:focus, input[type=\"url\"]:focus, input[type=\"week\"]:focus, input:not([type]):focus, textarea:focus:{border-color:black;}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiState()
        {
            string selectors = _shorthand.TextInputs(InteractionState.Active, InteractionState.Focus);
            string actual = $"{selectors}:{{border-color:black;}}";
            string expected = "input[type=\"color\"]:active, input[type=\"date\"]:active, input[type=\"datetime\"]:active, input[type=\"datetime-local\"]:active, input[type=\"email\"]:active, input[type=\"month\"]:active, input[type=\"number\"]:active, input[type=\"password\"]:active, input[type=\"search\"]$:active, input[type=\"tel\"]:active, input[type=\"text\"]:active, input[type=\"time\"]:active, input[type=\"url\"]:active, input[type=\"week\"]:active, input:not([type]):active, textarea:active, input[type=\"color\"]:focus, input[type=\"date\"]:focus, input[type=\"datetime\"]:focus, input[type=\"datetime-local\"]:focus, input[type=\"email\"]:focus, input[type=\"month\"]:focus, input[type=\"number\"]:focus, input[type=\"password\"]:focus, input[type=\"search\"]$:focus, input[type=\"tel\"]:focus, input[type=\"text\"]:focus, input[type=\"time\"]:focus, input[type=\"url\"]:focus, input[type=\"week\"]:focus, input:not([type]):focus, textarea:focus:{border-color:black;}";
            Assert.AreEqual(expected, actual);
        }
    }
}
