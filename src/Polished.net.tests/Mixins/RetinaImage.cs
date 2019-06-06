using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Polished.Tests.Mixins
{
    [TestClass]
    public class RetinaImage
    {
        private readonly IMixins _mixins = new Polished.Mixins();

        [TestMethod]
        public void ShowThrowIfNoFilename()
        {
            Assert.ThrowsException<PolishedException>(
                () => _mixins.RetinaImage(null, null)
            );
        }

        [TestMethod]
        public void Filename()
        {
            string actual = _mixins.RetinaImage("img", null);
            string expected = "background-image:url(img.png);@media only screen and (-webkit-min-device-pixel-ratio: 1.3),only screen and (min--moz-device-pixel-ratio: 1.3),only screen and (-o-min-device-pixel-ratio: 1.3/1),only screen and (min-resolution: 125dpi),only screen and (min-resolution: 1.3dppx){background-image:url(img_2x.png);}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilenameAndCover()
        {
            string actual = _mixins.RetinaImage("img", "cover");
            string expected = "background-image:url(img.png);@media only screen and (-webkit-min-device-pixel-ratio: 1.3),only screen and (min--moz-device-pixel-ratio: 1.3),only screen and (-o-min-device-pixel-ratio: 1.3/1),only screen and (min-resolution: 125dpi),only screen and (min-resolution: 1.3dppx){background-image:url(img_2x.png);background-size:cover;}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilenameAndExtension()
        {
            string actual = _mixins.RetinaImage("img", null, "jpg");
            string expected = "background-image:url(img.jpg);@media only screen and (-webkit-min-device-pixel-ratio: 1.3),only screen and (min--moz-device-pixel-ratio: 1.3),only screen and (-o-min-device-pixel-ratio: 1.3/1),only screen and (min-resolution: 125dpi),only screen and (min-resolution: 1.3dppx){background-image:url(img_2x.jpg);}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilenameAndRetinaFilename()
        {
            string actual = _mixins.RetinaImage("img", null, null, "retina_img");
            string expected = "background-image:url(img.png);@media only screen and (-webkit-min-device-pixel-ratio: 1.3),only screen and (min--moz-device-pixel-ratio: 1.3),only screen and (-o-min-device-pixel-ratio: 1.3/1),only screen and (min-resolution: 125dpi),only screen and (min-resolution: 1.3dppx){background-image:url(retina_img.png);}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilenameAndSuffix()
        {
            string actual = _mixins.RetinaImage("img", null, null, null, "_5x");
            string expected = "background-image:url(img.png);@media only screen and (-webkit-min-device-pixel-ratio: 1.3),only screen and (min--moz-device-pixel-ratio: 1.3),only screen and (-o-min-device-pixel-ratio: 1.3/1),only screen and (min-resolution: 125dpi),only screen and (min-resolution: 1.3dppx){background-image:url(img_5x.png);}";
            Assert.AreEqual(expected, actual);
        }
    }
}
