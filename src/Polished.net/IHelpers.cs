namespace Polished
{
    public interface IHelpers
    {
        /// <summary>
        ///  Enables shorthand for direction-based properties. It accepts a property and up to four values that map to top, right, bottom, and left, respectively. 
        ///  You can optionally pass an empty string to get only the directional values as properties. 
        ///  You can also optionally pass a null argument for a directional value to ignore it.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        string DirectionalProperty(string property, params string[] args);

        /// <summary>
        /// Convert pixel value to ems. 
        /// </summary>
        /// <param name="pixels"></param>
        /// <returns></returns>
        string Em(string pixels);

        /// <summary>
        /// Convert pixel value to ems. The default base value is 16px, but can be changed by passing a
        /// second argument to the function.
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="numBase"></param>
        /// <returns></returns>
        string Em(string pixels, string numBase);

        /// <summary>
        /// Returns the unit of a css value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string GetUnit(string value);

        /// <summary>
        /// Returns the value and unit for a css value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        ValueAndUnit GetValueAndUnit(string value);

        /// <summary>
        /// Establish consistent measurements and spacial relationships throughout your projects 
        /// by incrementing an em or rem value up or down a defined scale. 
        /// We provide a list of commonly used scales as pre-defined variables.
        /// </summary>
        /// <param name="steps"></param>
        /// <param name="baseNum"></param>
        /// <param name="modularScaleRatio"></param>
        /// <returns></returns>
        string ModularScale(int steps, string baseNum = "1em", ModularScaleRatio modularScaleRatio = ModularScaleRatio.PerfectFourth);

        /// <summary>
        /// Convert pixel value to rems. 
        /// </summary>
        /// <param name="pixels"></param>
        /// <returns></returns>
        string Rem(string pixels);

        /// <summary>
        /// Convert pixel value to rems. The default base value is 16px, but can be changed by passing a
        /// second argument to the function.
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="numBase"></param>
        /// <returns></returns>
        string Rem(string pixels, string numBase);

        /// <summary>
        /// Returns a given CSS value minus its unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string StripUnit(string value);
    }
}