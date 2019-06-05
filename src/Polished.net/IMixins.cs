namespace Polished
{
    public interface IMixins
    {
        string Between(string fromSize, string toSize, string minScreen = "320px", string maxScreen = "1200px");
        string ClearFix(string parent = "&");
        string Cover(string offset = "0");
        string Ellipsis(string width = "100%");
        string FluidRange(FluidRangeConfiguration cssProp, string minScreen = "320px", string maxScreen = "1200px");
        string FluidRange(System.Collections.Generic.List<FluidRangeConfiguration> cssProps, string minScreen = "320px", string maxScreen = "1200px");
        string FontFace(FontFaceConfiguration fontFaceConfiguration);
        string FontFace(string fontFamily, string fontFilePath, string fontStretch, string fontStyle, string fontVariant, string fontWeight, System.Collections.Generic.List<string> fileFormats, bool formatHint, System.Collections.Generic.List<string> localFonts, string unicodeRange, string fontDisplay, string fontVariationSettings, string fontFeatureSettings);
        string HideText();
        string HideVisually();
        string HiDPI(double ratio = 1.3);
    }
}