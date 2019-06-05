using System.Collections.Generic;

namespace Polished
{
    public class LinearGradientConfiguration
    {
        public List<string> ColorStops { get; set; }
        public string ToDirection { get; set; }
        public string Fallback { get; set; }
    }
}