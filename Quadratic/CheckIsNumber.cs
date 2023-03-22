namespace Quadratic;

public class CheckIsNumber
{
    public float IsNumber(string? StrNum)
    {
        float outNum;
        
        bool successfullyParsed = float.TryParse(StrNum, out outNum);
        return (successfullyParsed) ? outNum : float.MinValue;
    }

    public string IsSomethingThere(float num)
    {
        return (num == float.MinValue) ? "Invalid Input" : num.ToString();
    }

    public bool IsIvalidOutput(float a, float b, float c)
    {
        return (a == float.MinValue || b == float.MinValue || c == float.MinValue) ? true : false;
    }
    
}