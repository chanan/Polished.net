using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

[assembly: InternalsVisibleToAttribute("Polished.net.tests")]
namespace Polished.Internal
{
    internal class InternalHelpers
    {
        public int Guard(int lowerBoundary, int upperBoundary, int value)
        {
            return Math.Max(lowerBoundary, Math.Min(upperBoundary, value));
        }

        public double Guard(double lowerBoundary, double upperBoundary, double value)
        {
            return Math.Max(lowerBoundary, Math.Min(upperBoundary, value));
        }

        /// <summary>
        /// Function helper that adds an array of states to a template of selectors. Used in textInputs and buttons.
        /// </summary>
        /// <param name="states"></param>
        /// <param name="template"></param>
        /// <param name="stateMap"></param>
        /// <returns></returns>
        public string StatefulSelectors(List<string> states, Func<string, string> template, List<string> stateMap)
        {
            if (template == null)
            {
                throw PolishedException.GetPolishedException(67);
            }

            if (states.Count == 0)
            {
                return GenerateSelectors(template, null);
            }

            List<string> selectors = new List<string>();
            for (int i = 0; i < states.Count; i += 1)
            {
                if (stateMap != null && !stateMap.Contains(states[i]))
                {
                    throw PolishedException.GetPolishedException(68);
                }
                selectors.Add(GenerateSelectors(template, states[i]));
            }
            string ret = string.Join(", ", selectors);
            return ret.StripWhitespace();
        }

        /// <summary>
        /// Returns a given CSS value minus its unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string StripUnit(string value)
        {
            return Regex.Replace(value, "[^0-9.]", "");
        }

        /// <summary>
        /// Factory function that creates pixel-to-x converters
        /// </summary>
        /// <param name="to"></param>
        /// <returns></returns>
        public Func<string, string, string> PxToFactory(string to)
        {
            return new Func<string, string, string>((pxVal, numBase) =>
            {
                bool pxInt = int.TryParse(pxVal, out int i);
                if (!pxInt && !pxVal.EndsWith("px"))
                {
                    throw PolishedException.GetPolishedException(69, to, pxVal);
                }
                if (!double.TryParse(StripUnit(pxVal), out double newPxVal))
                {
                    throw PolishedException.GetPolishedException(71, pxVal, to);
                }

                bool numBaseInt = int.TryParse(numBase, out int j);
                if (numBase != null && !numBaseInt && !numBase.EndsWith("px"))
                {
                    throw PolishedException.GetPolishedException(70, to, numBase);
                }
                string numBaseStriped = numBase != null ? StripUnit(numBase) : "16.0";
                if (!double.TryParse(numBaseStriped, out double newBase))
                {
                    throw PolishedException.GetPolishedException(72, numBase, to);
                }

                double ret = newPxVal / newBase;
                return $"{ret}{to}";
            });
        }

        private string GenerateSelectors(Func<string, string> template, string state)
        {
            string arg = state != null ? state : "";
            return template(arg);
        }
    }
}
