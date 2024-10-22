using CSharpFunctionalExtensions;
using Onix.SharedKernel;

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
    
    public Result<Appearance, Error> Update(
        string colorScheme,
        string buttonStyle,
        string font)
    {
        return new Appearance(
            colorScheme,
            buttonStyle,
            font);
    }
}