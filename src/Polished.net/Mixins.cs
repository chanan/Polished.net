using Polished.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Polished
{
    public class Mixins : IMixins
    {
        private readonly IHelpers _helpers = new Helpers();
        private readonly Dictionary<string, string> _formatHintMap = new Dictionary<string, string>
        {
            { "woff", "woff" },
            { "woff2", "woff2" },
            { "ttf", "truetype" },
            {"otf", "opentype" },
            { "eot", "embedded-opentype" },
            {"svg", "svg" },
            { "svgz", "svg" },
        };

        private readonly Dictionary<TimingFunction, string> _timingMap = new Dictionary<TimingFunction, string>
        {
            {TimingFunction.EaseInBack,"cubic-bezier(0.600, -0.280, 0.735, 0.045)"},
            {TimingFunction.EaseInCirc,"cubic-bezier(0.600,  0.040, 0.980, 0.335)"},
            {TimingFunction.EaseInCubic,"cubic-bezier(0.550,  0.055, 0.675, 0.190)"},
            {TimingFunction.EaseInExpo,"cubic-bezier(0.950,  0.050, 0.795, 0.035)"},
            {TimingFunction.EaseInQuad,"cubic-bezier(0.550,  0.085, 0.680, 0.530)"},
            {TimingFunction.EaseInQuart,"cubic-bezier(0.895,  0.030, 0.685, 0.220)"},
            {TimingFunction.EaseInQuint,"cubic-bezier(0.755,  0.050, 0.855, 0.060)"},
            {TimingFunction.EaseInSine,"cubic-bezier(0.470,  0.000, 0.745, 0.715)"},
            {TimingFunction.EaseOutBack,"cubic-bezier(0.175,  0.885, 0.320, 1.275)"},
            {TimingFunction.EaseOutCubic,"cubic-bezier(0.215,  0.610, 0.355, 1.000)"},
            {TimingFunction.EaseOutCirc,"cubic-bezier(0.075,  0.820, 0.165, 1.000)"},
            {TimingFunction.EaseOutExpo,"cubic-bezier(0.190,  1.000, 0.220, 1.000)"},
            {TimingFunction.EaseOutQuad,"cubic-bezier(0.250,  0.460, 0.450, 0.940)"},
            {TimingFunction.EaseOutQuart,"cubic-bezier(0.165,  0.840, 0.440, 1.000)"},
            {TimingFunction.EaseOutQuint,"cubic-bezier(0.230,  1.000, 0.320, 1.000)"},
            {TimingFunction.EaseOutSine,"cubic-bezier(0.390,  0.575, 0.565, 1.000)"},
            {TimingFunction.EaseInOutBack,"cubic-bezier(0.680, -0.550, 0.265, 1.550)"},
            {TimingFunction.EaseInOutCirc,"cubic-bezier(0.785,  0.135, 0.150, 0.860)"},
            {TimingFunction.EaseInOutCubic,"cubic-bezier(0.645,  0.045, 0.355, 1.000)"},
            {TimingFunction.EaseInOutExpo,"cubic-bezier(1.000,  0.000, 0.000, 1.000)"},
            {TimingFunction.EaseInOutQuad,"cubic-bezier(0.455,  0.030, 0.515, 0.955)"},
            {TimingFunction.EaseInOutQuart,"cubic-bezier(0.770,  0.000, 0.175, 1.000)"},
            {TimingFunction.EaseInOutQuint,"cubic-bezier(0.860,  0.000, 0.070, 1.000)"},
            {TimingFunction.EaseInOutSine,"cubic-bezier(0.445,  0.050, 0.550, 0.950)"}
        };

        /// <inheritdoc />
        public string Between(string fromSize, string toSize, string minScreen = "320px", string maxScreen = "1200px")
        {
            ValueAndUnit fromSizeValueAndUnit = _helpers.GetValueAndUnit(fromSize);
            ValueAndUnit toSizeValueAndUnit = _helpers.GetValueAndUnit(toSize);
            ValueAndUnit minScreenValueAndUnit = _helpers.GetValueAndUnit(minScreen);
            ValueAndUnit maxScreenValueAndUnit = _helpers.GetValueAndUnit(maxScreen);

            if (!double.TryParse(fromSizeValueAndUnit.Value, out double fromSizeNum) ||
               !double.TryParse(toSizeValueAndUnit.Value, out double toSizeNum) ||
               string.IsNullOrWhiteSpace(fromSizeValueAndUnit.Unit) ||
               string.IsNullOrWhiteSpace(toSizeValueAndUnit.Unit) ||
               fromSizeValueAndUnit.Unit != toSizeValueAndUnit.Unit)
            {
                throw PolishedException.GetPolishedException(47);
            }

            if (!double.TryParse(minScreenValueAndUnit.Value, out double minScreenNum) ||
               !double.TryParse(maxScreenValueAndUnit.Value, out double maxScreenNum) ||
               string.IsNullOrWhiteSpace(minScreenValueAndUnit.Unit) ||
               string.IsNullOrWhiteSpace(maxScreenValueAndUnit.Unit) ||
               minScreenValueAndUnit.Unit != maxScreenValueAndUnit.Unit)
            {
                throw PolishedException.GetPolishedException(48);
            }

            double slope = (fromSizeNum - toSizeNum) / (minScreenNum - maxScreenNum);
            double baseNum = toSizeNum - slope * maxScreenNum;
            return $"calc({Math.Round(baseNum, 2)}{fromSizeValueAndUnit.Unit} + {Math.Round(100 * slope, 2)}vw)";
        }

        /// <inheritdoc />
        public string ClearFix(string parent = "&")
        {
            string pseudoSelector = $"{parent}:after";
            return $"{pseudoSelector}{{clear:both;content:\"\";display:table;}}";
        }

        /// <inheritdoc />
        public string Cover(string offset = "0")
        {
            return $"position:absolute;top:{offset};right:{offset};bottom:{offset};left:{offset};";
        }

        /// <inheritdoc />
        public string Ellipsis(string width = "100%")
        {
            return $"display:inline-block;max-width:{width};overflow:hidden;text-overflow:ellipsis;white-space:nowrap;word-wrap:normal;";
        }

        /// <inheritdoc />
        public string FluidRange(FluidRangeConfiguration cssProp, string minScreen = "320px", string maxScreen = "1200px")
        {
            if (cssProp == null)
            {
                throw PolishedException.GetPolishedException(49);
            }

            if (string.IsNullOrWhiteSpace(cssProp.Prop) || string.IsNullOrWhiteSpace(cssProp.FromSize) || string.IsNullOrWhiteSpace(cssProp.ToSize))
            {
                throw PolishedException.GetPolishedException(51);
            }
            string between = Between(cssProp.FromSize, cssProp.ToSize, minScreen, maxScreen);
            return $"{cssProp.Prop}:{cssProp.FromSize};@media(min-width:{minScreen}){{{cssProp.Prop}:{between};}}@media(min-width:{maxScreen}){{{cssProp.Prop}:{cssProp.ToSize};}}";
        }

        /// <inheritdoc />
        public string FluidRange(List<FluidRangeConfiguration> cssProps, string minScreen = "320px", string maxScreen = "1200px")
        {
            StringBuilder fallbacks = new StringBuilder();
            StringBuilder minSb = new StringBuilder();
            StringBuilder maxSb = new StringBuilder();

            minSb.Append("@media(min-width:").Append(minScreen).Append("){");
            maxSb.Append("@media(min-width:").Append(maxScreen).Append("){");

            if (cssProps == null || cssProps.Count == 0)
            {
                throw PolishedException.GetPolishedException(49);
            }

            foreach (FluidRangeConfiguration cssProp in cssProps)
            {
                if (string.IsNullOrWhiteSpace(cssProp.Prop) || string.IsNullOrWhiteSpace(cssProp.FromSize) || string.IsNullOrWhiteSpace(cssProp.ToSize))
                {
                    throw PolishedException.GetPolishedException(50);
                }

                string between = Between(cssProp.FromSize, cssProp.ToSize, minScreen, maxScreen);
                fallbacks.Append($"{cssProp.Prop}:{cssProp.FromSize};");
                minSb.Append(cssProp.Prop).Append(":").Append(between).Append(";");
                maxSb.Append(cssProp.Prop).Append(":").Append(cssProp.ToSize).Append(";");
            }

            minSb.Append("}");
            maxSb.Append("}");

            return fallbacks.ToString() + minSb.ToString() + maxSb.ToString();
        }

        /// <inheritdoc />
        public string FontFace(FontFaceConfiguration fontFaceConfiguration)
        {
            return FontFace(fontFaceConfiguration.FontFamily, fontFaceConfiguration.FontFilePath, fontFaceConfiguration.FontStretch,
                fontFaceConfiguration.FontStyle, fontFaceConfiguration.FontVariant, fontFaceConfiguration.FontWeight,
                fontFaceConfiguration.FileFormats, fontFaceConfiguration.FormatHint, fontFaceConfiguration.LocalFonts,
                fontFaceConfiguration.UnicodeRange, fontFaceConfiguration.FontDisplay, fontFaceConfiguration.FontVariationSettings,
                fontFaceConfiguration.FontFeatureSettings);
        }


        /// <inheritdoc />
        public string FontFace(string fontFamily, string fontFilePath, string fontStretch, string fontStyle, string fontVariant, string fontWeight,
            List<string> fileFormats, bool formatHint, List<string> localFonts, string unicodeRange, string fontDisplay, string fontVariationSettings,
            string fontFeatureSettings)
        {
            if (string.IsNullOrWhiteSpace(fontFamily))
            {
                throw PolishedException.GetPolishedException(55);
            }

            if (fileFormats == null || fileFormats.Count == 0)
            {
                fileFormats = new List<string> { "eot", "woff2", "woff", "ttf", "svg" };
            }

            if (string.IsNullOrWhiteSpace(fontFilePath) && localFonts == null)
            {
                throw PolishedException.GetPolishedException(52);
            }

            if (localFonts != null && localFonts.Count == 0)
            {
                throw PolishedException.GetPolishedException(53);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("@font-face{");
            sb.Append("font-family:").Append(fontFamily).Append(";");
            sb.Append("src:").Append(GenerateSources(fontFilePath, localFonts, fileFormats, formatHint)).Append(";");
            if (unicodeRange != null)
            {
                sb.Append("unicode-range:").Append(unicodeRange).Append(";");
            }

            if (fontStretch != null)
            {
                sb.Append("font-stretch:").Append(fontStretch).Append(";");
            }

            if (fontStyle != null)
            {
                sb.Append("font-style:").Append(fontStyle).Append(";");
            }

            if (fontVariant != null)
            {
                sb.Append("font-variant:").Append(fontVariant).Append(";");
            }

            if (fontWeight != null)
            {
                sb.Append("font-weight:").Append(fontWeight).Append(";");
            }

            if (fontDisplay != null)
            {
                sb.Append("font-display:").Append(fontDisplay).Append(";");
            }

            if (fontVariant != null)
            {
                sb.Append("font-variant:").Append(fontVariant).Append(";");
            }

            if (fontVariationSettings != null)
            {
                sb.Append("font-variant-settings:").Append(fontVariationSettings).Append(";");
            }

            if (fontFeatureSettings != null)
            {
                sb.Append("font-feature-settings:").Append(fontFeatureSettings).Append(";");
            }

            sb.Append("}");
            return sb.ToString();
        }

        /// <inheritdoc />
        public string HiDPI(double ratio = 1.3)
        {
            return $"@media only screen and (-webkit-min-device-pixel-ratio: {ratio}),only screen and (min--moz-device-pixel-ratio: {ratio}),only screen and (-o-min-device-pixel-ratio: {ratio}/1),only screen and (min-resolution: {Math.Round(ratio * 96)}dpi),only screen and (min-resolution: {ratio}dppx)";
        }

        /// <inheritdoc />
        public string HideText()
        {
            return "text-indent:101%;overflow:hidden;white-space:nowrap;";
        }

        /// <inheritdoc />
        public string HideVisually()
        {
            return "border:0,clip:rect(0 0 0 0),clip-path:inset(50%),height:1px,margin:-1px,overflow:hidden,padding:0,position:absolute,white-space:nowrap,width:1px;";
        }

        /// <inheritdoc />
        public string LinearGradient(LinearGradientConfiguration linearGradientConfiguration)
        {
            return LinearGradient(linearGradientConfiguration.ColorStops, linearGradientConfiguration.Fallback, linearGradientConfiguration.ToDirection);
        }

        /// <inheritdoc />
        public string LinearGradient(List<string> colorStops, string fallback, string toDirection)
        {
            if (colorStops == null || colorStops.Count < 2)
            {
                throw PolishedException.GetPolishedException(56);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("background-color:").Append(fallback ?? colorStops[0].Split(' ')[0]).Append(";");
            sb.Append("background-image:").Append("linear-gradient(");
            if (!string.IsNullOrWhiteSpace(toDirection))
            {
                sb.Append(toDirection).Append(", ");
            }

            sb.Append(string.Join(", ", colorStops));
            sb.Append(");");
            return sb.ToString();
        }

        /// <inheritdoc />
        public string Normalize()
        {
            return @"html {
                line-height: 1.15;
                    -webkit-text-size-adjust: 100%;
                }

                body {
                  margin: 0;
                }

                main {
                  display: block;
                }

                h1 {
                  font-size: 2em;
                  margin: 0.67em 0;
                }

                hr {
                  box-sizing: content-box;
                  height: 0;
                  overflow: visible;
                }

                pre {
                  font-family: monospace, monospace;
                  font-size: 1em;
                }

                a {
                  background-color: transparent;
                }

                abbr[title] {
                  border-bottom: none;
                  text-decoration: underline;
                  text-decoration: underline dotted;
                }

                b,
                strong {
                  font-weight: bolder;
                }

                code,
                kbd,
                samp {
                  font-family: monospace, monospace;
                  font-size: 1em;
                }

                small {
                  font-size: 80%;
                }

                sub,
                sup {
                  font-size: 75%;
                  line-height: 0;
                  position: relative;
                  vertical-align: baseline;
                }

                sub {
                  bottom: -0.25em;
                }

                sup {
                  top: -0.5em;
                }

                img {
                  border-style: none;
                }

                button,
                input,
                optgroup,
                select,
                textarea {
                  font-family: inherit;
                  font-size: 100%;
                  line-height: 1.15;
                  margin: 0;
                }

                button,
                input {
                  overflow: visible;
                }

                button,
                select {
                  text-transform: none;
                }

                button,
                [type=""button""],
                [type=""reset""],
                [type=""submit""] {
                  -webkit-appearance: button;
                }

                button::-moz-focus-inner,
                [type=""button""]::-moz-focus-inner,
                [type=""reset""]::-moz-focus-inner,
                [type=""submit""]::-moz-focus-inner {
                  border-style: none;
                  padding: 0;
                }

                button:-moz-focusring,
                [type=""button""]:-moz-focusring,
                [type=""reset""]:-moz-focusring,
                [type=""submit""]:-moz-focusring {
                  outline: 1px dotted ButtonText;
                }

                fieldset {
                  padding: 0.35em 0.75em 0.625em;
                }

                legend {
                  box-sizing: border-box;
                  color: inherit;
                  display: table;
                  max-width: 100%;
                  padding: 0;
                  white-space: normal;
                }

                progress {
                  vertical-align: baseline;
                }

                textarea {
                  overflow: auto;
                }

                [type=""checkbox""],
                [type=""radio""] {
                  box-sizing: border-box;
                  padding: 0;
                }

                [type=""number""]::-webkit-inner-spin-button,
                [type=""number""]::-webkit-outer-spin-button {
                  height: auto;
                }

                [type=""search""] {
                  -webkit-appearance: textfield;
                  outline-offset: -2px;
                }

                [type=""search""]::-webkit-search-decoration {
                  -webkit-appearance: none;
                }

                ::-webkit-file-upload-button {
                  -webkit-appearance: button;
                  font: inherit;
                }

                details {
                  display: block;
                }

                summary {
                  display: list-item;
                }

                template {
                  display: none;
                }

                [hidden] {
                  display: none;
                }
            ".StripWhitespace();
        }

        /// <inheritdoc />
        public string RadialGradient(RadialGradientConfiguration radialGradientConfiguration)
        {
            return RadialGradient(radialGradientConfiguration.ColorStops, radialGradientConfiguration.Extent,
                radialGradientConfiguration.Fallback, radialGradientConfiguration.Position, radialGradientConfiguration.Shape);
        }

        /// <inheritdoc />
        public string RadialGradient(List<string> colorStops, string extent, string fallback, string position, string shape)
        {
            if (colorStops == null || colorStops.Count < 2)
            {
                throw PolishedException.GetPolishedException(57);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("background-color:").Append(fallback ?? colorStops[0].Split(' ')[0]).Append(";");
            sb.Append("background-image:").Append("radial-gradient(");
            sb.Append(RadialGradientFirstValue(position, shape, extent));
            sb.Append(string.Join(", ", colorStops));
            sb.Append(");");
            return sb.ToString();
        }

        /// <inheritdoc />
        public string RetinaImage(string filename, string backgroundSize, string extension = "png", string retinaFilename = "", string retinaSuffix = "_2x")
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw PolishedException.GetPolishedException(58);
            }

            string ext = string.IsNullOrWhiteSpace(extension) ? "png" : extension.Replace(".", "");
            string rFilename = !string.IsNullOrWhiteSpace(retinaFilename) ? $"{retinaFilename}.{ext}" : $"{filename}{retinaSuffix}.{ext}";
            string rBackgroundSize = !string.IsNullOrWhiteSpace(backgroundSize) ? $"background-size:{backgroundSize};" : "";
            return $"background-image:url({filename}.{ext});{HiDPI()}{{background-image:url({rFilename});{rBackgroundSize}}}";
        }

        /// <inheritdoc />
        public string TimingFunctions(TimingFunction timingFunction)
        {
            return _timingMap[timingFunction];
        }

        /// <inheritdoc />
        public string Triangle(TriangleConfiguration triangleConfiguration)
        {
            return Triangle(triangleConfiguration.PointingDirection, triangleConfiguration.Height, triangleConfiguration.Width,
                triangleConfiguration.ForegroundColor, triangleConfiguration.BackgroundColor);
        }

        /// <inheritdoc />
        public string Triangle(Side pointingDirection, string height, string width, string foregroundColor, string backgroundColor = "transparent")
        {
            ValueAndUnit heightAndUnit = _helpers.GetValueAndUnit(height);
            ValueAndUnit widthAndUnit = _helpers.GetValueAndUnit(width);
            if (!double.TryParse(heightAndUnit.Value, out double h) || !double.TryParse(widthAndUnit.Value, out double w))
            {
                throw PolishedException.GetPolishedException(60);
            }
            string backgourndColorDefault = !string.IsNullOrWhiteSpace(backgroundColor) ? backgroundColor : "transparent";
            StringBuilder sb = new StringBuilder();
            sb.Append("width:0;");
            sb.Append("height:0;");
            sb.Append("border-color:").Append(GetBorderColor(pointingDirection, foregroundColor, backgourndColorDefault)).Append(";");
            sb.Append("border-style:solid;");
            sb.Append("border-width:").Append(GetBorderWidth(pointingDirection, heightAndUnit, widthAndUnit)).Append(";");
            return sb.ToString();
        }

        /// <inheritdoc />
        public string WordWrap(string wrap = "break-word")
        {
            string wrapDefault = !string.IsNullOrWhiteSpace(wrap) ? wrap : "break-word";
            string wordBreak = wrapDefault == "break-word" ? "break-all" : wrapDefault;
            return $"overflow-wrap:{wrapDefault};word-wrap:{wrapDefault};word-break:{wordBreak};";
        }

        private string GetBorderWidth(Side pointingDirection, ValueAndUnit heightAndUnit, ValueAndUnit widthAndUnit)
        {
            string fullWidth = $"{widthAndUnit.Value}{widthAndUnit.Unit}";
            string halfWidth = $"{double.Parse(widthAndUnit.Value) / 2}{widthAndUnit.Unit}";
            string fullHeight = $"{heightAndUnit.Value}{heightAndUnit.Unit}";
            string halfHeight = $"{double.Parse(heightAndUnit.Value) / 2}{heightAndUnit.Unit}";

            switch (pointingDirection)
            {
                case Side.Top:
                    return $"0 {halfWidth} {fullHeight} {halfWidth}";
                case Side.TopLeft:
                    return $"{fullWidth} {fullHeight} 0 0";
                case Side.Left:
                    return $"{halfHeight} {fullWidth} {halfHeight} 0";
                case Side.BottomLeft:
                    return $"{fullWidth} 0 0 {fullHeight}";
                case Side.Bottom:
                    return $"{fullHeight} {halfWidth} 0 {halfWidth}";
                case Side.BottomRight:
                    return $"0 0 {fullWidth} {fullHeight}";
                case Side.Right:
                    return $"{halfHeight} 0 {halfHeight} {fullWidth}";
                case Side.TopRight:
                default:
                    return $"0 {fullWidth} {fullHeight} 0";
            }
        }

        private string GetBorderColor(Side pointingDirection, string foregroundColor, string backgroundColor)
        {
            switch (pointingDirection)
            {
                case Side.Top:
                case Side.BottomRight:
                    return $"{backgroundColor} {backgroundColor} {foregroundColor} {backgroundColor}";
                case Side.Right:
                case Side.BottomLeft:
                    return $"{backgroundColor} {backgroundColor} {backgroundColor} {foregroundColor}";
                case Side.Bottom:
                case Side.TopLeft:
                    return $"{foregroundColor} {backgroundColor} {backgroundColor} {backgroundColor}";
                case Side.Left:
                case Side.TopRight:
                default:
                    return $"{backgroundColor} {foregroundColor} {backgroundColor} {backgroundColor}";
            }
        }

        private string RadialGradientFirstValue(string position, string shape, string extent)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(position))
            {
                sb.Append(position).Append(" ");
            }

            if (!string.IsNullOrWhiteSpace(shape))
            {
                sb.Append(shape).Append(" ");
            }

            if (!string.IsNullOrWhiteSpace(extent))
            {
                sb.Append(extent).Append(" ");
            }

            string ret = sb.ToString();
            if (string.IsNullOrWhiteSpace(ret))
            {
                return string.Empty;
            }
            else
            {
                return ret.Substring(0, ret.Length - 1) + ", ";
            }
        }

        private string GenerateSources(string fontFilePath, List<string> localFonts, List<string> fileFormats, bool formatHint)
        {
            List<string> fontReferences = new List<string>();
            if (localFonts != null && localFonts.Count != 0)
            {
                fontReferences.Add(GenerateLocalReferences(localFonts));
            }

            if (!string.IsNullOrWhiteSpace(fontFilePath))
            {
                fontReferences.Add(GenerateFileReferences(fontFilePath, fileFormats, formatHint));
            }
            return string.Join(",", fontReferences);
        }

        private string GenerateFileReferences(string fontFilePath, List<string> fileFormats, bool formatHint)
        {
            if (IsDataUri(fontFilePath))
            {
                return $"url(\"{fontFilePath}\"){GenerateFormatHint(fileFormats[0], formatHint)}";
            }

            List<string> fileFontReferences = fileFormats.Select(format => $"url(\"{fontFilePath}.{format}\"){GenerateFormatHint(format, formatHint)}").ToList();

            return string.Join(",", fileFontReferences);
        }

        private object GenerateFormatHint(string format, bool formatHint)
        {
            if (formatHint == false)
            {
                return "";
            }

            return $" format(\"{ _formatHintMap[format]}\")";
        }

        private bool IsDataUri(string fontFilePath)
        {
            string dataURIRegex = @"^\s*data:([a-z]+\/[a-z-]+(;[a-z-]+=[a-z-]+)?)?(;charset=[a-z0-9-]+)?(;base64)?,[a-z0-9!$&',()*+,;=\-._~:@/?%\s]*\s*$";
            return new Regex(dataURIRegex, RegexOptions.IgnoreCase).IsMatch(fontFilePath);
        }

        private string GenerateLocalReferences(List<string> localFonts)
        {
            List<string> localFontReferences = localFonts.Select(font => $"local(\"{font}\")").ToList();
            return string.Join(",", localFontReferences);
        }
    }
}
