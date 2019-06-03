using Polished.Internal;
using System;
using System.Linq;
using System.Text.RegularExpressions;


namespace Polished
{
    public class RgbColor
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public double? Alpha { get; set; }

        private readonly Conversion _conversion = new Conversion();

        /// <summary>
        /// Returns the luminance of a color.
        /// </summary>
        /// <returns></returns>
        public double GetLuminance()
        {
            double ret = 0.2126 * GetModifier(Red) + 0.7152 * GetModifier(Green) + 0.0722 * GetModifier(Blue);
            return Math.Round(ret, 3);
        }

        /// <summary>
        /// Returns the contrast ratio between two colors based on
        /// [W3's recommended equation for calculating contrast](http://www.w3.org/TR/WCAG20/#contrast-ratiodef).
        /// </summary>
        /// <param name="rgbColor"></param>
        /// <returns></returns>
        public double GetContrast(RgbColor rgbColor)
        {
            double luminance1 = GetLuminance();
            double luminance2 = rgbColor.GetLuminance();
            double ret = luminance1 > luminance2 ?
                (luminance1 + 0.05) / (luminance2 + 0.05) :
                (luminance2 + 0.05) / (luminance1 + 0.05);
            return Math.Round(ret, 2);
        }

        /// <summary>
        /// Inverts the red, green and blue values of a color.
        /// </summary>
        /// <returns></returns>
        public RgbColor Invert()
        {
            return new RgbColor
            {
                Red = 255 - Red,
                Green = 255 - Green,
                Blue = 255 - Blue,
                Alpha = Alpha
            };
        }

        /// <summary>
        /// Determines which contrast guidelines have been met for two colors.
        /// Based on the [contrast calculations recommended by W3] (https://www.w3.org/WAI/WCAG21/Understanding/contrast-enhanced.html).
        /// </summary>
        /// <param name="rgbColor"></param>
        /// <returns></returns>
        public ContrastScore MeetsContrastGuidelines(RgbColor rgbColor)
        {
            double contrastRatio = GetContrast(rgbColor);
            return new ContrastScore
            {
                AA = contrastRatio >= 4.5,
                AALarge = contrastRatio >= 3,
                AAA = contrastRatio >= 7,
                AAALarge = contrastRatio >= 4.5,
            };
        }

        /// <summary>
        /// Mixes the two provided colors together by calculating the average of each of the RGB components weighted to the first color by the provided weight.
        /// </summary>
        /// <param name="otherColor"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public RgbColor Mix(RgbColor otherColor, double weight)
        {
            RgbColor color1 = new RgbColor
            {
                Red = Red,
                Green = Green,
                Blue = Blue,
                Alpha = Alpha.HasValue ? Alpha : 1
            };

            RgbColor color2 = new RgbColor
            {
                Red = otherColor.Red,
                Green = otherColor.Green,
                Blue = otherColor.Blue,
                Alpha = otherColor.Alpha.HasValue ? otherColor.Alpha : 1
            };

            // The formular is copied from the original Sass implementation:
            // http://sass-lang.com/documentation/Sass/Script/Functions.html#mix-instance_method
            double alphaDelta = color1.Alpha.Value - color2.Alpha.Value;
            double x = weight * 2 - 1;
            double y = x * alphaDelta == -1 ? x : x + alphaDelta;
            double z = 1 + x * alphaDelta;
            double weight1 = (y / z + 1) / 2;
            double weight2 = 1 - weight1;
            RgbColor mixedColor = new RgbColor
            {
                Red = (int)Math.Floor(color1.Red * weight1 + color2.Red * weight2),
                Green = (int)Math.Floor(color1.Green * weight1 + color2.Green * weight2),
                Blue = (int)Math.Floor(color1.Blue * weight1 + color2.Blue * weight2),
                Alpha = color1.Alpha + (color2.Alpha - color1.Alpha) * weight
            };

            return mixedColor;
        }

        /// <summary>
        /// Increases the opacity of a color. Its range for the amount is between 0 to 1.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public RgbColor Opacify(double amount)
        {
            double alpha = Alpha.HasValue ? Alpha.Value : 1;
            return new RgbColor
            {
                Alpha = InternalHelpers.Guard(0, 1, (alpha * 100 + amount * 100) / 100),
                Red = Red,
                Green = Green,
                Blue = Blue
            };
        }

        /// <summary>
        /// Returns an HslColor object from a string.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static RgbColor Parse(string color)
        {
            string hexRegex = "^#[a-fA-F0-9]{6}$";
            string hexRgbaRegex = "^#[a-fA-F0-9]{8}$";
            string reducedHexRegex = "^#[a-fA-F0-9]{3}$";
            string reducedRgbaHexRegex = "^#[a-fA-F0-9]{4}$";
            string rgbRegex = @"rgb\(\s*(\d{1,3})\s*,\s*(\d{1,3})\s*,\s*(\d{1,3})\s*\)$";
            string rgbaRegex = @"^rgba\(\s*(\d{1,3})\s*,\s*(\d{1,3})\s*,\s*(\d{1,3})\s*,\s*([-+]?[0-9]*[.]?[0-9]+)\s*\)$";
            string hslRegex = @"^hsl\(\s*(\d{0,3}[.]?[0-9]+)\s*,\s*(\d{1,3})%\s*,\s*(\d{1,3})%\s*\)$";
            string hslaRegex = @"^hsla\(\s*(\d{0,3}[.]?[0-9]+)\s*,\s*(\d{1,3})%\s*,\s*(\d{1,3})%\s*,\s*([-+]?[0-9]*[.]?[0-9]+)\s*\)$";

            Conversion conversion = new Conversion();
            string normalizedColor = conversion.NameToHex(color);

            if (Regex.IsMatch(normalizedColor, hexRegex))
            {
                return new RgbColor
                {
                    Red = int.Parse($"{normalizedColor[1]}{normalizedColor[2]}", System.Globalization.NumberStyles.HexNumber),
                    Green = int.Parse($"{normalizedColor[3]}{normalizedColor[4]}", System.Globalization.NumberStyles.HexNumber),
                    Blue = int.Parse($"{normalizedColor[5]}{normalizedColor[6]}", System.Globalization.NumberStyles.HexNumber)
                };
            }
            if (Regex.IsMatch(normalizedColor, hexRgbaRegex))
            {
                double alpha = Math.Round(
                    ((double)int.Parse($"{normalizedColor[7]}{normalizedColor[8]}", System.Globalization.NumberStyles.HexNumber) / 255)
                , 2);
                return new RgbColor
                {
                    Red = int.Parse($"{normalizedColor[1]}{normalizedColor[2]}", System.Globalization.NumberStyles.HexNumber),
                    Green = int.Parse($"{normalizedColor[3]}{normalizedColor[4]}", System.Globalization.NumberStyles.HexNumber),
                    Blue = int.Parse($"{normalizedColor[5]}{normalizedColor[6]}", System.Globalization.NumberStyles.HexNumber),
                    Alpha = alpha
                };
            }
            if (Regex.IsMatch(normalizedColor, reducedHexRegex))
            {
                return new RgbColor
                {
                    Red = int.Parse($"{normalizedColor[1]}{normalizedColor[1]}", System.Globalization.NumberStyles.HexNumber),
                    Green = int.Parse($"{normalizedColor[2]}{normalizedColor[2]}", System.Globalization.NumberStyles.HexNumber),
                    Blue = int.Parse($"{normalizedColor[3]}{normalizedColor[3]}", System.Globalization.NumberStyles.HexNumber)
                };
            }
            if (Regex.IsMatch(normalizedColor, reducedRgbaHexRegex))
            {
                double alpha = Math.Round(
                    ((double)int.Parse($"{normalizedColor[4]}{normalizedColor[4]}", System.Globalization.NumberStyles.HexNumber) / 255)
                , 2);
                return new RgbColor
                {
                    Red = int.Parse($"{normalizedColor[1]}{normalizedColor[1]}", System.Globalization.NumberStyles.HexNumber),
                    Green = int.Parse($"{normalizedColor[2]}{normalizedColor[2]}", System.Globalization.NumberStyles.HexNumber),
                    Blue = int.Parse($"{normalizedColor[3]}{normalizedColor[3]}", System.Globalization.NumberStyles.HexNumber),
                    Alpha = alpha
                };
            }
            MatchCollection rgbMatched = new Regex(rgbRegex, RegexOptions.IgnoreCase).Matches(normalizedColor);
            if (rgbMatched.Count > 0)
            {
                return new RgbColor
                {
                    Red = int.Parse(rgbMatched[0].Groups[1].Value),
                    Green = int.Parse(rgbMatched[0].Groups[2].Value),
                    Blue = int.Parse(rgbMatched[0].Groups[3].Value)
                };
            }
            MatchCollection rgbaMatched = new Regex(rgbaRegex, RegexOptions.IgnoreCase).Matches(normalizedColor);
            if (rgbaMatched.Count > 0)
            {
                return new RgbColor
                {
                    Red = int.Parse(rgbaMatched[0].Groups[1].Value),
                    Green = int.Parse(rgbaMatched[0].Groups[2].Value),
                    Blue = int.Parse(rgbaMatched[0].Groups[3].Value),
                    Alpha = double.Parse(rgbaMatched[0].Groups[4].Value)
                };
            }
            MatchCollection hslMatched = new Regex(hslRegex, RegexOptions.IgnoreCase).Matches(normalizedColor);
            if (hslMatched.Count > 0)
            {
                double hue = double.Parse(hslMatched[0].Groups[1].Value);
                double saturation = double.Parse(hslMatched[0].Groups[2].Value) / 100;
                double lightness = double.Parse(hslMatched[0].Groups[3].Value) / 100;
                HslColor hsl = new HslColor { Hue = hue, Saturation = saturation, Lightness = lightness };
                return hsl.ToRgb();
            }
            MatchCollection hslaMatched = new Regex(hslaRegex, RegexOptions.IgnoreCase).Matches(normalizedColor);
            if (hslaMatched.Count > 0)
            {
                double hue = double.Parse(hslaMatched[0].Groups[1].Value);
                double saturation = double.Parse(hslaMatched[0].Groups[2].Value) / 100;
                double lightness = double.Parse(hslaMatched[0].Groups[3].Value) / 100;
                HslColor hsl = new HslColor { Hue = hue, Saturation = saturation, Lightness = lightness };
                RgbColor rgba = hsl.ToRgb();
                rgba.Alpha = double.Parse(hslaMatched[0].Groups[4].Value);
                return rgba;
            }
            throw PolishedException.GetPolishedException(5);
        }

        /// <summary>
        /// Shades a color by mixing it with black. `shade` can produce
        /// hue shifts, where as `darken` manipulates the luminance channel and therefore
        /// doesn't produce hue shifts.
        /// </summary>
        /// <param name="percentage"></param>
        /// <returns></returns>
        public RgbColor Shade(double percentage)
        {
            return new RgbColor { Blue = 0, Green = 0, Red = 0 }.Mix(this, percentage);
        }

        /// <summary>
        /// Tints a color by mixing it with white. `tint` can produce
        /// hue shifts, where as `lighten` manipulates the luminance channel and therefore
        /// doesn't produce hue shifts.
        /// </summary>
        /// <param name="percentage"></param>
        /// <returns></returns>
        public RgbColor Tint(double percentage)
        {
            return new RgbColor { Blue = 255, Green = 255, Red = 255 }.Mix(this, percentage);
        }

        /// <summary>
        /// Converts the RgbColor object to an HslColor object.
        /// </summary>
        /// <returns></returns>
        public HslColor ToHsl()
        {
            double red = Red / 255d;
            double green = Green / 255d;
            double blue = Blue / 255d;

            double max = (new double[] { red, green, blue }).Max();
            double min = (new double[] { red, green, blue }).Min();
            double lightness = (max + min) / 2;

            if (max == min)
            {
                // achromatic
                if (Alpha.HasValue)
                {
                    return new HslColor { Hue = 0, Saturation = 0, Lightness = lightness, Alpha = Alpha };
                }
                else
                {
                    return new HslColor { Hue = 0, Saturation = 0, Lightness = lightness, Alpha = null };
                }
            }

            double hue;
            double delta = max - min;
            double saturation = lightness > 0.5 ? (delta / (2 - max - min)) : (delta / (max + min));

            if (max == red)
            {
                hue = ((green - blue) / delta + (green < blue ? 6 : 0));
            }
            else if (max == green)
            {
                hue = ((blue - red) / delta + 2);
            }
            else
            {
                // blue case
                hue = ((red - green) / delta + 4);
            }

            hue *= 60;
            if (Alpha.HasValue)
            {
                return new HslColor { Hue = hue, Saturation = saturation, Lightness = lightness, Alpha = Alpha };
            }
            else
            {
                return new HslColor { Hue = hue, Saturation = saturation, Lightness = lightness, Alpha = null };
            }
        }

        /// <summary>
        /// Converts the RgbColor object to a color string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Alpha.HasValue)
            {
                return Alpha >= 1 ?
                  _conversion.RgbToHex(this) :
                  $"rgba({Red},{Green},{Blue},{Alpha.Value})";
            }
            else
            {
                return _conversion.RgbToHex(this);
            }
        }

        /// <summary>
        /// Decreases the opacity of a color. Its range for the amount is between 0 to 1.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public RgbColor Transparentize(double amount)
        {
            double alpha = Alpha.HasValue ? Alpha.Value : 1;
            return new RgbColor
            {
                Alpha = InternalHelpers.Guard(0, 1, (alpha * 100 - amount * 100) / 100),
                Red = Red,
                Green = Green,
                Blue = Blue
            };
        }

        /// <summary>
        /// Returns an HslColor object from a string.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="rgbColor"></param>
        /// <returns></returns>
        public static bool TryParse(string color, out RgbColor rgbColor)
        {
            try
            {
                rgbColor = Parse(color);
                return true;
            }
            catch (Exception)
            {
                rgbColor = null;
                return false;
            }
        }

        private double GetModifier(int color)
        {
            double channel = color / 255.0;
            double modifer = channel <= 0.03928
                ? channel / 12.92
                : Math.Pow(((channel + 0.055) / 1.055), 2.4);
            return modifer;
        }
    }
}
