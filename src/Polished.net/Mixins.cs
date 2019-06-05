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

            //TODO: Not sure how constructGradientValue https://github.com/styled-components/polished/blob/master/src/internalHelpers/_constructGradientValue.js
            //fits in here.
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
