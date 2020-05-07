public class EnumString : System.Attribute
{
    public string Value { get; }
    
    public EnumString(string value) => 
        Value = value;
}

public class EnumFloat : System.Attribute
{
    public float Value { get; }
    
    public EnumFloat(float value) => 
        Value = value;
}

public class EnumBool : System.Attribute
{
    public bool Value { get; }
    
    public EnumBool(bool value) => 
        Value = value;
}

public static class EnumPro
{
    public static string getString<T>(this T value) where T : struct 
    {
        string output = string.Empty;

        var type = value.GetType();

        var fild = type.GetField(value.ToString());
        var attrs = fild.GetCustomAttributes(typeof(EnumString), false) as EnumString[];

        //다중으로 애트리뷰트를 준 경우, 첫번째 애트리뷰트의 값만 넘겨준다.
        if (attrs?.Length > 0)
            output = attrs[0].Value;

        return output;
    }
    
    public static float getFloat<T>(this T value) where T : struct 
    {
        float output = 0.0f;

        var type = value.GetType();

        var fild = type.GetField(value.ToString());
        var attrs = fild.GetCustomAttributes(typeof(EnumFloat), false) as EnumFloat[];

        //다중으로 애트리뷰트를 준 경우, 첫번째 애트리뷰트의 값만 넘겨준다.
        if (attrs?.Length > 0)
            output = attrs[0].Value;

        return output;
    }
    
    public static bool getBool<T>(this T value) where T : struct 
    {
        bool output = false;

        var type = value.GetType();

        var fild = type.GetField(value.ToString());
        var attrs = fild.GetCustomAttributes(typeof(EnumBool), false) as EnumBool[];

        //다중으로 애트리뷰트를 준 경우, 첫번째 애트리뷰트의 값만 넘겨준다.
        if (attrs?.Length > 0)
            output = attrs[0].Value;

        return output;
    }
}
