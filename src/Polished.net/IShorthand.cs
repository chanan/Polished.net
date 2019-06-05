namespace Polished
{
    public interface IShorthand
    {
        /// <summary>
        /// Shorthand for easily setting the animation property. Allows either multiple arrays with animations
        /// or a single animation spread over the arguments.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        string Animation(params string[] args);

        /// <summary>
        /// Shorthand for easily setting the animation property. Allows either multiple arrays with animations
        /// or a single animation spread over the arguments.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        string Animation(params string[][] args);

        /// <summary>
        /// Shorthand that accepts any number of backgroundImage values as parameters for creating a single background statement.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        string BackgroundImages(params string[] args);

        /// <summary>
        /// Shorthand that accepts any number of background values as parameters for creating a single background statement.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        string Backgrounds(params string[] args);

        /// <summary>
        /// Shorthand for the border property that splits out individual properties for use with tools like Fela and Styletron. 
        /// A side keyword can optionally be passed to target only one side's border properties.
        /// </summary>
        /// <param name="borderSide"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        string Border(params string[] args);

        /// <summary>
        /// Shorthand for the border property that splits out individual properties for use with tools like Fela and Styletron. 
        /// A side keyword can optionally be passed to target only one side's border properties.
        /// </summary>
        /// <param name="param"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        string Border(Side borderSide, params string[] args);

        /// <summary>
        /// Shorthand for the border property that splits out individual properties for use with tools like Fela and Styletron. 
        /// The first param can optionally be passed to target only one side's border properties.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        string Border(string param, params string[] args);

        /// <summary>
        /// Shorthand that accepts up to four values, including null to skip a value, and maps them to their respective directions.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        string BorderColor(params string[] args);

        /// <summary>
        /// Shorthand that accepts a value for side and a value for radius and applies the radius value to both corners of the side.
        /// </summary>
        /// <param name="side"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        string BorderRadius(Side side, string radius);

        /// <summary>
        /// Shorthand that accepts up to four values, including null to skip a value, and maps them to their respective directions.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        string BorderRadius(string side, string radius);

        /// <summary>
        /// Shorthand that accepts up to four values, including null to skip a value, and maps them to their respective directions.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        string BorderStyle(params string[] args);

        /// <summary>
        /// Shorthand that accepts up to four values, including null to skip a value, and maps them to their respective directions.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        string BorderWidth(params string[] args);

        /// <summary>
        /// Populates selectors that target all buttons. You can pass optional states to append to the selectors.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        string Buttons(params InteractionState[] states);

        /// <summary>
        /// Shorthand that accepts up to four values, including null to skip a value, and maps them to their respective directions.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        string Margin(params string[] args);

        /// <summary>
        /// Shorthand that accepts up to four values, including null to skip a value, and maps them to their respective directions.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        string Padding(params string[] args);

        /// <summary>
        /// Shorthand accepts up to five values, including null to skip a value, and maps them to their respective directions. 
        /// The first value is a position keyword.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        string Position(Position position, params string[] args);

        /// <summary>
        /// Shorthand accepts up to four values, including null to skip a value, and maps them to their respective directions. 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        string Position(params string[] args);

        /// <summary>
        /// Shorthand to set the height and width properties in a single statement.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        string Size(string height, string width);

        /// <summary>
        /// Shorthand to set the height and width properties in a single statement.
        /// Height is used for the width as well.
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        string Size(string height);

        /// <summary>
        /// Populates selectors that target all text inputs. You can pass optional states to append to the selectors.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        string TextInputs(params InteractionState[] states);

        /// <summary>
        /// Accepts any number of transition values as parameters for creating a single transition statement. 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        string Transitions(params string[] args);

        /// <summary>
        /// Accepts an array of properties as the first parameter that you would like to apply the same transition values to (second parameter).
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        string Transitions(System.Collections.Generic.List<string> properties, string transation);
    }
}