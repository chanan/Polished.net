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
    }
}