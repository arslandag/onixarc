namespace Onix.WebSites.Domain.Appearances;

public class Appearance
{
    //вынести
    private const string COLOR_SCHEME = "color scheme";
    private const string BUTTON_STYLE = "button style";
    private const string FONT = "font";
    
    private Appearance(
        string colorScheme,
        string buttonStyle,
        string font)
    {
        ColorScheme = colorScheme;
        ButtonStyle = buttonStyle;
        Font = font;
    }

    public string ColorScheme { get; }
    public string ButtonStyle { get; }
    public string Font { get; }

    public static Appearance Bases => new Appearance(
        COLOR_SCHEME,
        BUTTON_STYLE,
        FONT);
    
    public Appearance Update(
        string colorScheme = null,
        string buttonStyle = null,
        string font = null)
    {
        return new Appearance(
            colorScheme ?? this.ColorScheme,
            buttonStyle ?? this.ButtonStyle,
            font ?? this.Font
        );
    }
}