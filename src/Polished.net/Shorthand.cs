using Polished.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polished
{
    public class Shorthand : IShorthand
    {
        private readonly IHelpers _helpers = new Helpers();
        private readonly InternalHelpers _internalHelpers = new InternalHelpers();

        /// <inheritdoc />
        public string Animation(params string[] args)
        {
            if (args.Count() > 8)
            {
                throw PolishedException.GetPolishedException(64);
            }

            return "animation: " + string.Join(", ", args) + ";";
        }

        /// <inheritdoc />
        public string Animation(params string[][] args)
        {
            if (args.Max(arg => arg.Count()) > 8)
            {
                throw PolishedException.GetPolishedException(66);
            }

            List<string> ret = args.Select(arg => string.Join(" ", arg)).ToList();
            return "animation: " + string.Join(", ", ret) + ";";
        }

        /// <inheritdoc />
        public string BackgroundImages(params string[] args)
        {
            return "background-image: " + string.Join(", ", args) + ";";
        }

        /// <inheritdoc />
        public string Backgrounds(params string[] args)
        {
            return "background: " + string.Join(", ", args) + ";";
        }

        /// <inheritdoc />
        public string Border(Side borderSide, params string[] args)
        {
            string side = borderSide.ToString().ToLower();
            return $"border-{side}-width:{args[0]};border-{side}-style:{args[1]};border-{side}-color:{args[2]};";
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
        public string BorderColor(params string[] args)
        {
            return _helpers.DirectionalProperty("border-color", args);
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public string BorderRadius(string side, string radius)
        {
            Side SideEnum = (Side)Enum.Parse(typeof(Side), side.FirstCharToUpper());
            return BorderRadius(SideEnum, radius);
        }

        /// <inheritdoc />
        public string BorderStyle(params string[] args)
        {
            return _helpers.DirectionalProperty("border-style", args);
        }

        /// <inheritdoc />
        public string BorderWidth(params string[] args)
        {
            return _helpers.DirectionalProperty("border-width", args);
        }

        /// <inheritdoc />
        public string Buttons(params InteractionState[] states)
        {
            List<string> list = EnumListToStringList(states.Select(state => state.ToString()).ToList());
            List<string> stateMap = EnumListToStringList(Enum.GetNames(typeof(InteractionState)).ToList());
            return _internalHelpers.StatefulSelectors(list, ButtonTemplate, stateMap);
        }

        /// <inheritdoc />
        public string Margin(params string[] args)
        {
            return _helpers.DirectionalProperty("margin", args);
        }

        /// <inheritdoc />
        public string Padding(params string[] args)
        {
            return _helpers.DirectionalProperty("padding", args);
        }

        /// <inheritdoc />
        public string Position(Position position, params string[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("position:").Append(position.ToString().ToLower()).Append(';');
            sb.Append(_helpers.DirectionalProperty(null, args));
            return sb.ToString();
        }

        /// <inheritdoc />
        public string Position(params string[] args)
        {
            return _helpers.DirectionalProperty(null, args);
        }

        /// <inheritdoc />
        public string Size(string height, string width)
        {
            string widthVal = width != null ? width : height;
            return $"height:{height};width:{widthVal};";
        }

        /// <inheritdoc />
        public string Size(string height)
        {
            return Size(height, height);
        }

        /// <inheritdoc />
        public string TextInputs(params InteractionState[] states)
        {
            List<string> list = EnumListToStringList(states.Select(state => state.ToString()).ToList());
            List<string> stateMap = EnumListToStringList(Enum.GetNames(typeof(InteractionState)).ToList());
            return _internalHelpers.StatefulSelectors(list, TextInputsTemplate, stateMap);
        }

        /// <inheritdoc />
        public string Transitions(params string[] args)
        {
            return "transition: " + string.Join(", ", args) + ";";
        }

        /// <inheritdoc />
        public string Transitions(List<string> properties, string transation)
        {
            List<string> ret = properties.Select(prop => $"{prop} {transation}").ToList();
            return "transition: " + string.Join(", ", ret) + ";";
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

        private string TextInputsTemplate(string state)
        {
            return $@"input[type=""color""]{state},
            input[type=""date""]{state},
            input[type=""datetime""]{state},
            input[type=""datetime-local""]{state},
            input[type=""email""]{state},
            input[type=""month""]{ state},
            input[type=""number""]{state},
            input[type=""password""]{state},
            input[type=""search""]${ state},
            input[type=""tel""]{state},
            input[type=""text""]{state},
            input[type=""time""]{state},
            input[type=""url""]{state},
            input[type=""week""]{state},
            input:not([type]){state},
            textarea{state}";
        }
    }
}
