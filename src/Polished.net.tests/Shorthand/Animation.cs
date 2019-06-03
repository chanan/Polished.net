using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Shorthand
{
    [TestClass]
    public class Animation
    {
        private readonly IShorthand _shorthand = new Polished.Shorthand();

        [TestMethod]
        public void Use8Args()
        {
            string actual = _shorthand.Animation("rotate", "1s", "ease-in-out", "0.5s", "5", "reverse", "forwards", "paused");
            string expected = "animation: rotate, 1s, ease-in-out, 0.5s, 5, reverse, forwards, paused;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LessThan8Args()
        {
            string actual = _shorthand.Animation("rotate", "1s", "ease-in-out");
            string expected = "animation: rotate, 1s, ease-in-out;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MulitModeUse8Args()
        {
            string actual = _shorthand.Animation(new string[][] { new string[] { "rotate", "1s", "ease-in-out", "0.5s", "5", "reverse", "forwards", "paused" } });
            string expected = "animation: rotate 1s ease-in-out 0.5s 5 reverse forwards paused;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MulitModeLessThan8Args()
        {
            string actual = _shorthand.Animation(new string[][] { new string[] { "rotate", "1s", "ease-in-out" } });
            string expected = "animation: rotate 1s ease-in-out;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MulitModeTwoAnimations()
        {
            string actual = _shorthand.Animation(new string[][] { new string[] { "rotate", "1s", "ease-in-out" }, new string[] { "colorchange", "2s" } });
            string expected = "animation: rotate 1s ease-in-out, colorchange 2s;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThrowsIfMoreThan8Args()
        {
            Assert.ThrowsException<PolishedException>(
                () => _shorthand.Animation("one", "two", "three", "four", "five", "six", "seven", "eight", "oops")
            );
        }

        [TestMethod]
        public void MulitModeThrowsIfMoreThan8Args()
        {
            Assert.ThrowsException<PolishedException>(
                () => _shorthand.Animation(new string[][] {
                    new string[] { "rotate" },
                    new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "oops" }
                }
            ));
        }
    }
}
