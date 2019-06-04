namespace Polished
{
    public interface IHelpers
    {
        string DirectionalProperty(string property, params string[] args);
        string Em(string pixels);
        string Em(string pixels, string numBase);
        string ModularScale(int steps, string baseNum = "1em", ModularScaleRatio modularScaleRatio = ModularScaleRatio.PerfectFourth);
        string Rem(string pixels);
        string StripUnit(string value);
    }
}