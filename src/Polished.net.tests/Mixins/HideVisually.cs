using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Mixins
{
    [TestClass]
    public class HideVisually
    {
        private readonly IMixins _mixins = new Polished.Mixins();

        [TestMethod]
        public void Simple()
        {
            Assert.AreEqual("border:0,clip:rect(0 0 0 0),clip-path:inset(50%),height:1px,margin:-1px,overflow:hidden,padding:0,position:absolute,white-space:nowrap,width:1px;", _mixins.HideVisually());
        }

        [TestMethod]
        public void Div()
        {
            string actual = $".myclass{{background-image:url(logo.png);{_mixins.HideVisually()}}}";
            string expected = ".myclass{background-image:url(logo.png);border:0,clip:rect(0 0 0 0),clip-path:inset(50%),height:1px,margin:-1px,overflow:hidden,padding:0,position:absolute,white-space:nowrap,width:1px;}";
            Assert.AreEqual(expected, actual);
        }
    }
}
