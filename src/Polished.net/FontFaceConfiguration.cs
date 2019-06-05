using System.Collections.Generic;

namespace Polished
{
    public class FontFaceConfiguration
    {
        public string FontFamily { get; set; }
        public string FontFilePath { get; set; }
        public string FontStretch { get; set; }
        public string FontStyle { get; set; }
        public string FontVariant { get; set; }
        public string FontWeight { get; set; }
        public List<string> FileFormats { get; set; }
        public bool FormatHint { get; set; }
        public List<string> LocalFonts { get; set; }
        public string UnicodeRange { get; set; }
        public string FontDisplay { get; set; }
        public string FontVariationSettings { get; set; }
        public string FontFeatureSettings { get; set; }
    }
}
