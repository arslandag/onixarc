namespace Onix.WebSites.Domain.ConfigSite;

public class Appearance
{
    //вынести внешний вид
    public const string COLOR_SCHEME = "color scheme";
    public const int BUTTON_ANGLE = 10;
    public const string BUTTON_STYLE = "button style";
    public const string FONT = "font";
    public const string FAVICON = "null";
    
    private Appearance(
        string colorScheme,
        int buttonAngle,
        string buttonStyle,
        string font)
    {
        ColorScheme = colorScheme;
        ButtonAngle = buttonAngle;
        ButtonStyle = buttonStyle;
        Font = font;
    }

    public string ColorScheme { get; }
    public int ButtonAngle { get; }
    public string ButtonStyle { get; }
    public string Font { get; }

    public static Appearance Bases => new Appearance(
        COLOR_SCHEME,
        BUTTON_ANGLE,
        BUTTON_STYLE,
        FONT);
}