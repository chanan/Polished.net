using Polished.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Polished
{
    public class Helpers : IHelpers
    {
        private readonly string[] positionMap = new string[] { "top", "right", "bottom", "left" };
        private readonly InternalHelpers _internalHelpers = new InternalHelpers();
        private readonly Func<string, string, string> _em;
        private readonly Func<string, string, string> _rem;
        private readonly Dictionary<ModularScaleRatio, double> _ratioNames = new Dictionary<ModularScaleRatio, double>
        {
            { ModularScaleRatio.MinorSecond, 1.067 },
            { ModularScaleRatio.MajorSecond, 1.125 },
            { ModularScaleRatio.MinorThird, 1.2 },
            { ModularScaleRatio.MajorThird, 1.25 },
            { ModularScaleRatio.PerfectFourth, 1.333 },
            { ModularScaleRatio.AugFourth, 1.414 },
            { ModularScaleRatio.PerfectFifth, 1.5 },
            { ModularScaleRatio.MinorSixth, 1.6 },
            { ModularScaleRatio.GoldenSection, 1.618 },
            { ModularScaleRatio.MajorSixth, 1.667 },
            { ModularScaleRatio.MinorSeventh, 1.778 },
            { ModularScaleRatio.MajorSeventh, 1.875 },
            { ModularScaleRatio.Octave, 2 },
            { ModularScaleRatio.MajorTenth, 2.5 },
            { ModularScaleRatio.MajorEleventh, 2.667 },
            { ModularScaleRatio.MajorTwelfth, 3 },
            { ModularScaleRatio.DoubleOctave, 4 }
        };

        public Helpers()
        {
            _em = _internalHelpers.PxToFactory("em");
            _rem = _internalHelpers.PxToFactory("rem");
        }

        /// <summary>
        ///  Enables shorthand for direction-based properties. It accepts a property and up to four values that map to top, right, bottom, and left, respectively. 
        ///  You can optionally pass an empty string to get only the directional values as properties. 
        ///  You can also optionally pass a null argument for a directional value to ignore it.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public string DirectionalProperty(string property, params string[] args)
        {
            string[] valuesWithDefaults = new string[]
            {
                args[0],
                args.Length > 1 ? args[1] : args[0],
                args.Length > 2 ? args[2] : args[0],
                args.Length > 3 ? args[3] :
                    args.Length > 1 ? args[1] : args[0]
            };
            return GenerateStyles(property, valuesWithDefaults);
        }

        /// <summary>
        /// Convert pixel value to ems. 
        /// </summary>
        /// <param name="pixels"></param>
        /// <returns></returns>
        public string Em(string pixels)
        {
            return _em(pixels, null);
        }

        /// <summary>
        /// Convert pixel value to ems. The default base value is 16px, but can be changed by passing a
        /// second argument to the function.
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="numBase"></param>
        /// <returns></returns>
        public string Em(string pixels, string numBase)
        {
            return _em(pixels, numBase);
        }

        /// <summary>
        /// Returns the value and unit for a css value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ValueAndUnit GetValueAndUnit(string value)
        {
            return new ValueAndUnit
            {
                Value = StripUnit(value),
                Unit = GetUnit(value)
            };
        }

        /// <summary>
        /// Returns the unit of a css value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetUnit(string value)
        {
            return Regex.Replace(value, "[0-9.]", "");
        }

        /// <summary>
        /// Establish consistent measurements and spacial relationships throughout your projects 
        /// by incrementing an em or rem value up or down a defined scale. 
        /// We provide a list of commonly used scales as pre-defined variables.
        /// </summary>
        /// <param name="steps"></param>
        /// <param name="baseNum"></param>
        /// <param name="modularScaleRatio"></param>
        /// <returns></returns>
        public string ModularScale(int steps, string baseNum = "1em", ModularScaleRatio modularScaleRatio = ModularScaleRatio.PerfectFourth)
        {
            string unit = GetUnit(baseNum);
            if (!double.TryParse(StripUnit(baseNum), out double realBase))
            {
                throw PolishedException.GetPolishedException(44, baseNum);
            }
            double ratio = _ratioNames[modularScaleRatio];
            double ret = realBase * Math.Pow(ratio, steps);
            return $"{ret}{unit}";
        }

        /// <summary>
        /// Convert pixel value to rems. 
        /// </summary>
        /// <param name="pixels"></param>
        /// <returns></returns>
        public string Rem(string pixels)
        {
            return _rem(pixels, null);
        }

        /// <summary>
        /// Convert pixel value to rems. The default base value is 16px, but can be changed by passing a
        /// second argument to the function.
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="numBase"></param>
        /// <returns></returns>
        public string Rem(string pixels, string numBase)
        {
            return _rem(pixels, numBase);
        }

        /// <summary>
        /// Returns a given CSS value minus its unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string StripUnit(string value)
        {
            return _internalHelpers.StripUnit(value);
        }

        private string GenerateStyles(string property, params string[] valuesWithDefaults)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < valuesWithDefaults.Length; i += 1)
            {
                if (!string.IsNullOrWhiteSpace(valuesWithDefaults[i]))
                {
                    sb.Append(GenerateProperty(property, positionMap[i])).Append(':').Append(valuesWithDefaults[i]).Append(';');
                }
            }
            return sb.ToString();
        }

        private string GenerateProperty(string property, string position)
        {
            if (string.IsNullOrWhiteSpace(property))
            {
                return position.ToLower();
            }

            if (property.IndexOf('-') != -1)
            {
                string[] arr = property.Split('-');
                return $"{arr[0]}-{position}-{arr[1]}";
            }
            else
            {
                return $"{property}-{position}";
            }
        }
    }
}
