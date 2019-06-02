using System;

namespace Polished.Internal
{
    internal class Helpers
    {
        public static int Guard(int lowerBoundary, int upperBoundary, int value)
        {
            return Math.Max(lowerBoundary, Math.Min(upperBoundary, value));
        }

        public static double Guard(double lowerBoundary, double upperBoundary, double value)
        {
            return Math.Max(lowerBoundary, Math.Min(upperBoundary, value));
        }
    }
}
