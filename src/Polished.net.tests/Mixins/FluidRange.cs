using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Polished.Tests.Mixins
{
    [TestClass]
    public class FluidRange
    {
        private readonly IMixins _mixins = new Polished.Mixins();

        [TestMethod]
        public void SingleCssProp()
        {
            string actual = _mixins.FluidRange(new FluidRangeConfiguration { Prop = "padding", FromSize = "20px", ToSize = "100px" }, "400px", "1000px");
            string expected = "padding:20px;@media(min-width:400px){padding:calc(-33.33px + 13.33vw);}@media(min-width:1000px){padding:100px;}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiCssProps()
        {
            List<FluidRangeConfiguration> list = new List<FluidRangeConfiguration>
            {
                new FluidRangeConfiguration {Prop = "padding", FromSize = "20px", ToSize = "100px"},
                new FluidRangeConfiguration {Prop = "margin", FromSize = "5px", ToSize = "25px"}
            };
            string actual = _mixins.FluidRange(list, "400px", "1000px");
            string expected = "padding:20px;margin:5px;@media(min-width:400px){padding:calc(-33.33px + 13.33vw);margin:calc(-8.33px + 3.33vw);}@media(min-width:1000px){padding:100px;margin:25px;}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SingleCssPropDefaultScreenSizes()
        {
            string actual = _mixins.FluidRange(new FluidRangeConfiguration { Prop = "padding", FromSize = "20px", ToSize = "100px" });
            string expected = "padding:20px;@media(min-width:320px){padding:calc(-9.09px + 9.09vw);}@media(min-width:1200px){padding:100px;}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThrowsIfFirstIsNullObject()
        {
            FluidRangeConfiguration f = null;
            Assert.ThrowsException<PolishedException>(
                () => _mixins.FluidRange(f, "400px", "1000px")
            );
        }

        [TestMethod]
        public void ThrowsIfFirstIsNullList()
        {
            List<FluidRangeConfiguration> list = null;
            Assert.ThrowsException<PolishedException>(
                () => _mixins.FluidRange(list, "400px", "1000px")
            );
        }

        [TestMethod]
        public void ThrowsIfMissingProps()
        {
            List<FluidRangeConfiguration> list = new List<FluidRangeConfiguration>
            {
                new FluidRangeConfiguration {Prop = "padding", FromSize = "20px"}
            };
            Assert.ThrowsException<PolishedException>(
                () => _mixins.FluidRange(list, "400px", "1000px")
            );
        }

        [TestMethod]
        public void ThrowsIfMissingUnits()
        {
            List<FluidRangeConfiguration> list = new List<FluidRangeConfiguration>
            {
                new FluidRangeConfiguration {Prop = "padding", FromSize = "20px", ToSize = "100px"}
            };
            Assert.ThrowsException<PolishedException>(
                () => _mixins.FluidRange(list, "400", "1000")
            );
        }

        [TestMethod]
        public void ThrowsIfValuesAreNotValid()
        {
            List<FluidRangeConfiguration> list = new List<FluidRangeConfiguration>
            {
                new FluidRangeConfiguration {Prop = "padding", FromSize = "20px", ToSize = "100px"}
            };
            Assert.ThrowsException<PolishedException>(
                () => _mixins.FluidRange(list, "invalid", "invalid")
            );
        }

        [TestMethod]
        public void ThrowsIfValuesAreNotSameUnit()
        {
            List<FluidRangeConfiguration> list = new List<FluidRangeConfiguration>
            {
                new FluidRangeConfiguration {Prop = "padding", FromSize = "20px", ToSize = "100px"}
            };
            Assert.ThrowsException<PolishedException>(
                () => _mixins.FluidRange(list, "100px", "1000em")
            );
        }

        [TestMethod]
        public void ThrowsIfValuesForPropAreNotSameUnit()
        {
            List<FluidRangeConfiguration> list = new List<FluidRangeConfiguration>
            {
                new FluidRangeConfiguration {Prop = "padding", FromSize = "20px", ToSize = "100em"}
            };
            Assert.ThrowsException<PolishedException>(
                () => _mixins.FluidRange(list, "100px", "1000px")
            );
        }
    }
}
