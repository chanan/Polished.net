using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Polished.Tests.Mixins
{
    [TestClass]
    public class FontFace
    {
        private readonly IMixins _mixins = new Polished.Mixins();

        [TestMethod]
        public void FamilyAndSource()
        {
            string actual = _mixins.FontFace(new FontFaceConfiguration { FontFamily = "Sans Pro", FontFilePath = "path/to/file" });
            string expected = "@font-face{font-family:Sans Pro;src:url(\"path/to/file.eot\"),url(\"path/to/file.woff2\"),url(\"path/to/file.woff\"),url(\"path/to/file.ttf\"),url(\"path/to/file.svg\");}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FamilySourceAndLocal()
        {
            string actual = _mixins.FontFace(new FontFaceConfiguration { FontFamily = "Sans Pro", FontFilePath = "path/to/file", LocalFonts = new List<string> { "sans-pro" } });
            string expected = "@font-face{font-family:Sans Pro;src:local(\"sans-pro\"),url(\"path/to/file.eot\"),url(\"path/to/file.woff2\"),url(\"path/to/file.woff\"),url(\"path/to/file.ttf\"),url(\"path/to/file.svg\");}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FamilySourceAndMultiLocal()
        {
            string actual = _mixins.FontFace(new FontFaceConfiguration { FontFamily = "Sans Pro", FontFilePath = "path/to/file", LocalFonts = new List<string> { "sans-pro", "sans pro" } });
            string expected = "@font-face{font-family:Sans Pro;src:local(\"sans-pro\"),local(\"sans pro\"),url(\"path/to/file.eot\"),url(\"path/to/file.woff2\"),url(\"path/to/file.woff\"),url(\"path/to/file.ttf\"),url(\"path/to/file.svg\");}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FamilyAndMultiLocal()
        {
            string actual = _mixins.FontFace(new FontFaceConfiguration { FontFamily = "Sans Pro", LocalFonts = new List<string> { "sans-pro", "sans pro" } });
            string expected = "@font-face{font-family:Sans Pro;src:local(\"sans-pro\"),local(\"sans pro\");}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FamilySourceAndFileFormats()
        {
            string actual = _mixins.FontFace(new FontFaceConfiguration { FontFamily = "Sans Pro", FontFilePath = "path/to/file", FileFormats = new List<string> { "eot", "svg" } });
            string expected = "@font-face{font-family:Sans Pro;src:url(\"path/to/file.eot\"),url(\"path/to/file.svg\");}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Base64Src()
        {
            string actual = _mixins.FontFace(new FontFaceConfiguration { FontFamily = "Sans Pro", FontFilePath = "data:application/x-font-woff;charset=utf-8;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQAQMAAAAlPW0iAAAABlBMVEUAAAD///+l2Z/dAAAAM0lEQVR4nGP4/5/h/1+G/58ZDrAz3D/McH8yw83NDDeNGe4Ug9C9zwz3gVLMDA/A6P9/AFGGFyjOXZtQAAAAAElFTkSuQmCC" });
            string expected = "@font-face{font-family:Sans Pro;src:url(\"data:application/x-font-woff;charset=utf-8;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQAQMAAAAlPW0iAAAABlBMVEUAAAD///+l2Z/dAAAAM0lEQVR4nGP4/5/h/1+G/58ZDrAz3D/McH8yw83NDDeNGe4Ug9C9zwz3gVLMDA/A6P9/AFGGFyjOXZtQAAAAAElFTkSuQmCC\");}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Base64SrcWithFormatHint()
        {
            string actual = _mixins.FontFace(new FontFaceConfiguration
            {
                FontFamily = "Sans Pro",
                FileFormats = new List<string> { "woff" },
                FormatHint = true,
                FontFilePath = "data:application/x-font-woff;charset=utf-8;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQAQMAAAAlPW0iAAAABlBMVEUAAAD///+l2Z/dAAAAM0lEQVR4nGP4/5/h/1+G/58ZDrAz3D/McH8yw83NDDeNGe4Ug9C9zwz3gVLMDA/A6P9/AFGGFyjOXZtQAAAAAElFTkSuQmCC"
            });
            string expected = "@font-face{font-family:Sans Pro;src:url(\"data:application/x-font-woff;charset=utf-8;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQAQMAAAAlPW0iAAAABlBMVEUAAAD///+l2Z/dAAAAM0lEQVR4nGP4/5/h/1+G/58ZDrAz3D/McH8yw83NDDeNGe4Ug9C9zwz3gVLMDA/A6P9/AFGGFyjOXZtQAAAAAElFTkSuQmCC\") format(\"woff\");}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FontConfiguration()
        {
            string actual = _mixins.FontFace(new FontFaceConfiguration
            {
                FontFamily = "Sans Pro",
                FontFilePath = "path/to/file",
                FontStretch = "condensed",
                FontStyle = "italic",
                FontWeight = "bold",
                FontVariant = "small-caps",
                UnicodeRange = "U+26",
                FontDisplay = "swap",
                FontVariationSettings = "\"XHGT\" 0.7",
                FontFeatureSettings = "\"smcp\" on"
            });
            string expected = "@font-face{font-family:Sans Pro;src:url(\"path/to/file.eot\"),url(\"path/to/file.woff2\"),url(\"path/to/file.woff\"),url(\"path/to/file.ttf\"),url(\"path/to/file.svg\");unicode-range:U+26;font-stretch:condensed;font-style:italic;font-variant:small-caps;font-weight:bold;font-display:swap;font-variant:small-caps;font-variant-settings:\"XHGT\" 0.7;font-feature-settings:\"smcp\" on;}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FormatHints()
        {
            string actual = _mixins.FontFace(new FontFaceConfiguration
            {
                FontFamily = "Sans Pro",
                FontFilePath = "path/to/file",
                FileFormats = new List<string> { "eot", "svg", "svgz", "woff", "woff2", "otf", "ttf" },
                FormatHint = true,
                FontStretch = "condensed",
                FontStyle = "italic",
                FontWeight = "bold"
            });
            string expected = "@font-face{font-family:Sans Pro;src:url(\"path/to/file.eot\") format(\"embedded-opentype\"),url(\"path/to/file.svg\") format(\"svg\"),url(\"path/to/file.svgz\") format(\"svg\"),url(\"path/to/file.woff\") format(\"woff\"),url(\"path/to/file.woff2\") format(\"woff2\"),url(\"path/to/file.otf\") format(\"opentype\"),url(\"path/to/file.ttf\") format(\"truetype\");font-stretch:condensed;font-style:italic;font-weight:bold;}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThrowsIfNoFamily()
        {
            Assert.ThrowsException<PolishedException>(
                () => _mixins.FontFace(new FontFaceConfiguration { FontFilePath = "path/to/file" })
            );
        }

        [TestMethod]
        public void ThrowsIfNoPathOrSource()
        {
            Assert.ThrowsException<PolishedException>(
                () => _mixins.FontFace(new FontFaceConfiguration { FontFamily = "Sans Pro" })
            );
        }
    }
}
