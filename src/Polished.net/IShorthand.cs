namespace Polished
{
    public interface IShorthand
    {
        string Animation(params string[] args);
        string Animation(params string[][] args);
        string BackgroundImages(params string[] args);
        string Backgrounds(params string[] args);
        string Border(params string[] args);
        string Border(Side borderSide, params string[] args);
        string Border(string param, params string[] args);
        string BorderColor(params string[] args);
        string BorderRadius(Side side, string radius);
        string BorderRadius(string side, string radius);
        string BorderStyle(params string[] args);
        string BorderWidth(params string[] args);
        string Buttons(params InteractionState[] states);
        string Margin(params string[] args);
        string Padding(params string[] args);
        string Position(Position position, params string[] args);
        string Position(params string[] args);
        string Size(string height, string width);
        string Size(string height);
        string TextInputs(params InteractionState[] states);
        string Transitions(params string[] args);
        string Transitions(System.Collections.Generic.List<string> properties, string transation);
    }
}