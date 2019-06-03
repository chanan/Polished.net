using Polished.Internal;
using System;

namespace Polished
{
    public class HslColor
    {
        public double Hue { get; set; }
        public double Saturation { get; set; }
        public double Lightness { get; set; }
        public double? Alpha { get; set; }

        private readonly Conversion _conversion = new Conversion();

        /// <summary>
        /// Changes the hue of the color. Hue is a number between 0 to 360. The first
        /// argument for adjustHue is the amount of degrees the color is rotated around
        /// the color wheel, always producing a positive hue value.
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public HslColor AdjustHue(double degree)
        {
            return new HslColor
            {
                Alpha = Alpha,
                Hue = Hue + degree,
                Lightness = Lightness,
                Saturation = Saturation
            };
        }

        /// <summary>
        /// Returns the complement of the provided color. This is identical to adjustHue(180, <color>).
        /// </summary>
        /// <returns></returns>
        public HslColor Complement()
        {
            return new HslColor
            {
                Alpha = Alpha,
                Hue = (Hue + 180) % 360,
                Lightness = Lightness,
                Saturation = Saturation
            };
        }

        /// <summary>
        /// Returns a string value for the darkened color.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public HslColor Darken(double amount)
        {
            return new HslColor
            {
                Alpha = Alpha,
                Hue = Hue,
                Lightness = InternalHelpers.Guard(0d, 1d, Lightness - amount),
                Saturation = Saturation
            };
        }

        /// <summary>
        /// Decreases the intensity of a color. Its range is between 0 to 1. The first
        /// argument of the desaturate function is the amount by how much the color
        /// intensity should be decreased.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public HslColor Desaturate(double amount)
        {
            return new HslColor
            {
                Alpha = Alpha,
                Hue = Hue,
                Lightness = Lightness,
                Saturation = InternalHelpers.Guard(0d, 1d, Saturation - amount)
            };
        }

        /// <summary>
        /// Converts the color to a grayscale, by reducing its saturation to 0.
        /// </summary>
        /// <returns></returns>
        public HslColor Greyscale()
        {
            return new HslColor
            {
                Alpha = Alpha,
                Hue = Hue,
                Lightness = Lightness,
                Saturation = 0
            };
        }

        /// <summary>
        /// Returns a string value for the lightened color.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public HslColor Lighten(double amount)
        {
            return new HslColor
            {
                Alpha = Alpha,
                Hue = Hue,
                Lightness = InternalHelpers.Guard(0d, 1d, Lightness + amount),
                Saturation = Saturation
            };
        }

        /// <summary>
        /// Returns an HslColor object from a string.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static HslColor Parse(string color)
        {
            return RgbColor.Parse(color).ToHsl();
        }

        /// <summary>
        /// Increases the intensity of a color. Its range is between 0 to 1. The first
        /// argument of the saturate function is the amount by how much the color
        /// intensity should be increased.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public HslColor Saturate(double amount)
        {
            return new HslColor
            {
                Alpha = Alpha,
                Hue = Hue,
                Lightness = Lightness,
                Saturation = InternalHelpers.Guard(0d, 1d, Saturation + amount)
            };
        }

        /// <summary>
        /// Converts the HslColor object to an RgbColor object.
        /// </summary>
        /// <returns></returns>
        public RgbColor ToRgb()
        {
            return RgbColor.Parse(ToString());
        }

        /// <summary>
        /// Converts the HslColor object to a color string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Alpha.HasValue)
            {
                return Alpha >= 1 ?
                    _conversion.ToRgb(this, _conversion.ConvertToHex) :
                    $"rgba({_conversion.ToRgb(this, _conversion.ConvertToInt)},{Alpha})";
            }
            else
            {
                return _conversion.ToRgb(this, _conversion.ConvertToHex);
            }
        }

        /// <summary>
        /// Returns an HslColor object from a string.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="hslColor"></param>
        /// <returns></returns>
        public static bool TryParse(string color, out HslColor hslColor)
        {
            try
            {
                hslColor = Parse(color);
                return true;
            }
            catch (Exception)
            {
                hslColor = null;
                return false;
            }
        }
    }
}