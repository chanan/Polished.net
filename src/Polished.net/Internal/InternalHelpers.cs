using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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

        private string GenerateSelectors(Func<string, string> template, string state)
        {
            string arg = state != null ? state : "";
            return template(arg);
        }
    }
}
