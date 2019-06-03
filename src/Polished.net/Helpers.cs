using System.Text;

namespace Polished
{
    public static class Helpers
    {
        private static readonly string[] positionMap = new string[] { "top", "right", "bottom", "left" };

        /// <summary>
        ///  Enables shorthand for direction-based properties. It accepts a property and up to four values that map to top, right, bottom, and left, respectively. 
        ///  You can optionally pass an empty string to get only the directional values as properties. 
        ///  You can also optionally pass a null argument for a directional value to ignore it.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string DirectionalProperty(string property, params string[] args)
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

        private static string GenerateStyles(string property, params string[] valuesWithDefaults)
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

        private static string GenerateProperty(string property, string position)
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
