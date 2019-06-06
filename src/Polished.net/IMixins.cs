namespace Polished
{
    public interface IMixins
    {
        /// <summary>
        /// Returns a CSS calc formula for linear interpolation of a property between two values.
        /// Accepts optional minScreen (defaults to '320px') and maxScreen (defaults to '1200px').
        /// </summary>
        /// <param name="fromSize"></param>
        /// <param name="toSize"></param>
        /// <param name="minScreen"></param>
        /// <param name="maxScreen"></param>
        /// <returns></returns>
        string Between(string fromSize, string toSize, string minScreen = "320px", string maxScreen = "1200px");

        /// <summary>
        /// CSS to contain a float (credit to CSSMojo).
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        string ClearFix(string parent = "&");

        /// <summary>
        /// CSS to fully cover an area. Can optionally be passed an offset to act as a "padding".
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        string Cover(string offset = "0");

        /// <summary>
        /// CSS to represent truncated text with an ellipsis.
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        string Ellipsis(string width = "100%");

        /// <summary>
        /// Returns a set of media queries that resizes a property (or set of properties) between a provided fromSize and toSize.
        /// Accepts optional minScreen (defaults to '320px') and maxScreen (defaults to '1200px') to constrain the interpolation.
        /// </summary>
        /// <param name="cssProp"></param>
        /// <param name="minScreen"></param>
        /// <param name="maxScreen"></param>
        /// <returns></returns>
        string FluidRange(FluidRangeConfiguration cssProp, string minScreen = "320px", string maxScreen = "1200px");

        /// <summary>
        /// Returns a set of media queries that resizes a property (or set of properties) between a provided fromSize and toSize.
        /// Accepts optional minScreen (defaults to '320px') and maxScreen (defaults to '1200px') to constrain the interpolation.
        /// </summary>
        /// <param name="cssProps"></param>
        /// <param name="minScreen"></param>
        /// <param name="maxScreen"></param>
        /// <returns></returns>
        string FluidRange(System.Collections.Generic.List<FluidRangeConfiguration> cssProps, string minScreen = "320px", string maxScreen = "1200px");

        /// <summary>
        /// CSS for a @font-face declaration.
        /// </summary>
        /// <param name="fontFaceConfiguration"></param>
        /// <returns></returns>
        string FontFace(FontFaceConfiguration fontFaceConfiguration);

        /// <summary>
        /// CSS for a @font-face declaration.
        /// </summary>
        /// <param name="fontFamily"></param>
        /// <param name="fontFilePath"></param>
        /// <param name="fontStretch"></param>
        /// <param name="fontStyle"></param>
        /// <param name="fontVariant"></param>
        /// <param name="fontWeight"></param>
        /// <param name="fileFormats"></param>
        /// <param name="formatHint"></param>
        /// <param name="localFonts"></param>
        /// <param name="unicodeRange"></param>
        /// <param name="fontDisplay"></param>
        /// <param name="fontVariationSettings"></param>
        /// <param name="fontFeatureSettings"></param>
        /// <returns></returns>
        string FontFace(string fontFamily, string fontFilePath, string fontStretch, string fontStyle, string fontVariant, string fontWeight, System.Collections.Generic.List<string> fileFormats, bool formatHint, System.Collections.Generic.List<string> localFonts, string unicodeRange, string fontDisplay, string fontVariationSettings, string fontFeatureSettings);

        /// <summary>
        /// Generates a media query to target HiDPI devices.
        /// </summary>
        /// <param name="ratio"></param>
        /// <returns></returns>
        string HideText();

        /// <summary>
        /// CSS to hide text to show a background image in a SEO-friendly way.
        /// </summary>
        /// <returns></returns>
        string HideVisually();

        /// <summary>
        /// CSS to hide content visually but remain accessible to screen readers.
        /// from[HTML5 Boilerplate] (https://github.com/h5bp/html5-boilerplate/blob/9a176f57af1cfe8ec70300da4621fb9b07e5fa31/src/css/main.css#L121)
        /// </summary>
        /// <returns></returns>
        string HiDPI(double ratio = 1.3);

        /// <summary>
        /// CSS for declaring a linear gradient, including a fallback background-color. 
        /// The fallback is either the first color-stop or an explicitly passed fallback color.
        /// </summary>
        /// <param name="linearGradientConfiguration"></param>
        /// <returns></returns>
        string LinearGradient(LinearGradientConfiguration linearGradientConfiguration);

        /// <summary>
        /// CSS for declaring a linear gradient, including a fallback background-color. 
        /// The fallback is either the first color-stop or an explicitly passed fallback color.
        /// </summary>
        /// <param name="linearGradientConfiguration"></param>
        /// <returns></returns>
        string LinearGradient(System.Collections.Generic.List<string> colorStops, string fallback, string toDirection = "");

        /// <summary>
        /// CSS to normalize abnormalities across browsers (normalize.css v8.0.1 | MIT License | github.com/necolas/normalize.css)
        /// </summary>
        /// <returns></returns>
        string Normalize();

        /// <summary>
        /// CSS for declaring a radial gradient, including a fallback background-color. 
        /// The fallback is either the first color-stop or an explicitly passed fallback color.
        /// </summary>
        /// <param name="radialGradientConfiguration"></param>
        /// <returns></returns>
        string RadialGradient(RadialGradientConfiguration radialGradientConfiguration);

        /// <summary>
        /// CSS for declaring a radial gradient, including a fallback background-color. 
        /// The fallback is either the first color-stop or an explicitly passed fallback color.
        /// </summary>
        /// <param name="colorStops"></param>
        /// <param name="extent"></param>
        /// <param name="fallback"></param>
        /// <param name="position"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
        string RadialGradient(System.Collections.Generic.List<string> colorStops, string extent, string fallback, string position, string shape);

        /// <summary>
        /// A helper to generate a retina background image and non-retina
        /// background image.The retina background image will output to a HiDPI media query. The mixin uses
        /// a _2x.png filename suffix by default.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="backgroundSize"></param>
        /// <param name="extension"></param>
        /// <param name="retinaFilename"></param>
        /// <param name="retinaSuffix"></param>
        /// <returns></returns>
        string RetinaImage(string filename, string backgroundSize, string extension = "png", string retinaFilename = "", string retinaSuffix = "_2x");

        /// <summary>
        /// String to represent common easing functions as demonstrated here: (github.com/jaukia/easie).
        /// </summary>
        /// <param name="timingFunction"></param>
        /// <returns></returns>
        string TimingFunctions(TimingFunction timingFunction);

        /// <summary>
        /// CSS to represent triangle with any pointing direction with an optional background color.
        /// </summary>
        /// <param name="triangleConfiguration"></param>
        /// <returns></returns>
        string Triangle(TriangleConfiguration triangleConfiguration);

        /// <summary>
        /// Provides an easy way to change the `wordWrap` property.
        /// </summary>
        /// <param name="wrap"></param>
        /// <returns></returns>
        string WordWrap(string wrap = "break-word");
    }
}