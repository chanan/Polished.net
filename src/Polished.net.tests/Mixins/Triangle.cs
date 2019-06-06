using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Mixins
{
    [TestClass]
    public class Triangle
    {
        private readonly IMixins _mixins = new Polished.Mixins();

        [TestMethod]
        public void AllParamsNoUnits()
        {
            string actual = _mixins.Triangle(new TriangleConfiguration
            {
                ForegroundColor = "red",
                BackgroundColor = "black",
                PointingDirection = Side.Right,
                Height = "10",
                Width = "20"
            }
            );
            string expected = "width:0;height:0;border-color:black black black red;border-style:solid;border-width:5 0 5 20;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AllParamsWithUnits()
        {
            string actual = _mixins.Triangle(new TriangleConfiguration
            {
                ForegroundColor = "red",
                BackgroundColor = "black",
                PointingDirection = Side.Right,
                Height = "10em",
                Width = "20em"
            }
            );
            string expected = "width:0;height:0;border-color:black black black red;border-style:solid;border-width:5em 0 5em 20em;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AllParamsWithDoublesAndUnits()
        {
            string actual = _mixins.Triangle(new TriangleConfiguration
            {
                ForegroundColor = "red",
                BackgroundColor = "black",
                PointingDirection = Side.Right,
                Height = "10.5em",
                Width = "20.5em"
            }
            );
            string expected = "width:0;height:0;border-color:black black black red;border-style:solid;border-width:5.25em 0 5.25em 20.5em;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultsToTransparent()
        {
            string actual = _mixins.Triangle(new TriangleConfiguration
            {
                ForegroundColor = "red",
                PointingDirection = Side.Right,
                Height = "10px",
                Width = "20px"
            }
            );
            string expected = "width:0;height:0;border-color:transparent transparent transparent red;border-style:solid;border-width:5px 0 5px 20px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TopArrow()
        {
            string actual = _mixins.Triangle(new TriangleConfiguration
            {
                ForegroundColor = "green",
                PointingDirection = Side.Top,
                Height = "20px",
                Width = "20px"
            }
            );
            string expected = "width:0;height:0;border-color:transparent transparent green transparent;border-style:solid;border-width:0 10px 20px 10px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RightArrow()
        {
            string actual = _mixins.Triangle(new TriangleConfiguration
            {
                ForegroundColor = "red",
                PointingDirection = Side.Right,
                Height = "10px",
                Width = "20px"
            }
            );
            string expected = "width:0;height:0;border-color:transparent transparent transparent red;border-style:solid;border-width:5px 0 5px 20px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BottomArrow()
        {
            string actual = _mixins.Triangle(new TriangleConfiguration
            {
                ForegroundColor = "red",
                PointingDirection = Side.Bottom,
                Height = "20px",
                Width = "10px"
            }
            );
            string expected = "width:0;height:0;border-color:red transparent transparent transparent;border-style:solid;border-width:20px 5px 0 5px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LeftArrow()
        {
            string actual = _mixins.Triangle(new TriangleConfiguration
            {
                ForegroundColor = "blue",
                PointingDirection = Side.Left,
                Height = "20px",
                Width = "10px"
            }
            );
            string expected = "width:0;height:0;border-color:transparent blue transparent transparent;border-style:solid;border-width:10px 10px 10px 0;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TopRightArrow()
        {
            string actual = _mixins.Triangle(new TriangleConfiguration
            {
                ForegroundColor = "blue",
                PointingDirection = Side.TopRight,
                Height = "20px",
                Width = "20px"
            }
            );
            string expected = "width:0;height:0;border-color:transparent blue transparent transparent;border-style:solid;border-width:0 20px 20px 0;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BottomRightArrow()
        {
            string actual = _mixins.Triangle(new TriangleConfiguration
            {
                ForegroundColor = "blue",
                PointingDirection = Side.BottomRight,
                Height = "20px",
                Width = "20px"
            }
            );
            string expected = "width:0;height:0;border-color:transparent transparent blue transparent;border-style:solid;border-width:0 0 20px 20px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BottomLeftArrow()
        {
            string actual = _mixins.Triangle(new TriangleConfiguration
            {
                ForegroundColor = "blue",
                PointingDirection = Side.BottomLeft,
                Height = "20px",
                Width = "20px"
            }
            );
            string expected = "width:0;height:0;border-color:transparent transparent transparent blue;border-style:solid;border-width:20px 0 0 20px;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TopLeftArrow()
        {
            string actual = _mixins.Triangle(new TriangleConfiguration
            {
                ForegroundColor = "blue",
                PointingDirection = Side.TopLeft,
                Height = "20px",
                Width = "20px"
            }
            );
            string expected = "width:0;height:0;border-color:blue transparent transparent transparent;border-style:solid;border-width:20px 20px 0 0;";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThrowsWhenHeightOrWidthNotNumbers()
        {
            Assert.ThrowsException<PolishedException>(
                () => _mixins.Triangle(new TriangleConfiguration
                {
                    ForegroundColor = "blue",
                    PointingDirection = Side.TopLeft,
                    Height = "inherit",
                    Width = "inherit"
                })
            );
        }
    }
}
