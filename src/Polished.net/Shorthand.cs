using Polished.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Polished
{
    public class Shorthand : IShorthand
    {
        private readonly IHelpers _helpers = new Helpers();
        private readonly InternalHelpers _internalHelpers = new InternalHelpers();

        /// <summary>
        /// Shorthand for easily setting the animation property. Allows either multiple arrays with animations
        /// or a single animation spread over the arguments.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public string Animation(params string[] args)
        {
            if (args.Count() > 8)
            {
                throw PolishedException.GetPolishedException(64);
            }

            return "animation: " + string.Join(", ", args) + ";";
        }

        /// <summary>
        /// Shorthand for easily setting the animation property. Allows either multiple arrays with animations
        /// or a single animation spread over the arguments.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public string Animation(params string[][] args)
        {
            if (args.Max(arg => arg.Count()) > 8)
            {
                throw PolishedException.GetPolishedException(66);
            }

            List<string> ret = args.Select(arg => string.Join(" ", arg)).ToList();
            return "animation: " + string.Join(", ", ret) + ";";
        }

        /// <summary>
        /// Shorthand that accepts any number of backgroundImage values as parameters for creating a single background statement.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public string BackgroundImages(params string[] args)
        {
            return "background-image: " + string.Join(", ", args) + ";";
        }

        /// <summary>
        /// Shorthand that accepts any number of background values as parameters for creating a single background statement.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public string Backgrounds(params string[] args)
        {
            return "background: " + string.Join(", ", args) + ";";
        }

        /// <summary>
        /// Shorthand for the border property that splits out individual properties for use with tools like Fela and Styletron. 
        /// A side keyword can optionally be passed to target only one side's border properties.
        /// </summary>
        /// <param name="borderSide"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public string Border(Side borderSide, params string[] args)
        {
            string side = borderSide.ToString().ToLower();
            return $"border-{side}-width:{args[0]};border-{side}-style:{args[1]};border-{side}-color:{args[2]};";
        }

        /// <summary>
        /// Shorthand for the border property that splits out individual properties for use with tools like Fela and Styletron. 
        /// A side keyword can optionally be passed to target only one side's border properties.
        /// </summary>
        /// <param name="param"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public string Border(string param, params string[] args)
        {
            string[] names = Enum.GetNames(typeof(Side));
            if (Array.Exists(names, name => name == param.FirstCharToUpper()))
            {
                return Border((Side)Enum.Parse(typeof(Side), param.FirstCharToUpper()), args);
            }

            List<string> list = new List<string> { param };
            list.AddRange(args);
            return Border(list.ToArray());
        }

        /// <summary>
        /// Shorthand for the border property that splits out individual properties for use with tools like Fela and Styletron. 
        /// The first param can optionally be passed to target only one side's border properties.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public string Border(params string[] args)
        {
            string[] names = Enum.GetNames(typeof(Side));
            if (Array.Exists(names, name => name == args[0].FirstCharToUpper()))
            {
                string[] list = args.Skip(1).ToArray();
                return Border((Side)Enum.Parse(typeof(Side), args[0].FirstCharToUpper()), list);
            }
            return $"border-width:{args[0]};border-style:{args[1]};border-color:{args[2]};";
        }

        /// <summary>
        /// Shorthand that accepts up to four values, including null to skip a value, and maps them to their respective directions.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public string BorderColor(params string[] args)
        {
            return _helpers.DirectionalProperty("border-color", args);
        }

        /// <summary>
        /// Shorthand that accepts a value for side and a value for radius and applies the radius value to both corners of the side.
        /// </summary>
        /// <param name="side"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public string BorderRadius(Side side, string radius)
        {
            string strSide = side.ToString().ToLower();
            if (side == Side.Top || side == Side.Bottom)
            {
                return $"border-{strSide}-right-radius:{radius};border-{strSide}-left-radius:{radius};";
            }
            else
            {
                return $"border-top-{strSide}-radius:{radius};border-bottom-{strSide}-radius:{radius};";
            }
        }

        /// <summary>
        /// Shorthand that accepts up to four values, including null to skip a value, and maps them to their respective directions.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public string BorderRadius(string side, string radius)
        {
            Side SideEnum = (Side)Enum.Parse(typeof(Side), side.FirstCharToUpper());
            return BorderRadius(SideEnum, radius);
        }

        /// <summary>
        /// Shorthand that accepts up to four values, including null to skip a value, and maps them to their respective directions.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public string BorderStyle(params string[] args)
        {
            return _helpers.DirectionalProperty("border-style", args);
        }

        /// <summary>
        /// Shorthand that accepts up to four values, including null to skip a value, and maps them to their respective directions.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public string BorderWidth(params string[] args)
        {
            return _helpers.DirectionalProperty("border-width", args);
        }

        /// <summary>
        /// Populates selectors that target all buttons. You can pass optional states to append to the selectors.
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        public string Buttons(params InteractionState[] states)
        {
            List<string> list = EnumListToStringList(states.Select(state => state.ToString()).ToList());
            List<string> stateMap = EnumListToStringList(Enum.GetNames(typeof(InteractionState)).ToList());
            return _internalHelpers.StatefulSelectors(list, ButtonTemplate, stateMap);
        }

        private List<string> EnumListToStringList(List<string> input)
        {
            List<string> ret = new List<string>();
            foreach (string str in input)
            {
                if (str == "Base")
                {
                    ret.Add(null);
                }
                else
                {
                    ret.Add(':' + str.ToLower());
                }
            }
            return ret;
        }

        private string ButtonTemplate(string state)
        {
            return $@"button{state},
                input[type=""button""]{state},
                input[type=""reset""]{state},
                input[type=""submit""]{state}";
        }
    }
}
