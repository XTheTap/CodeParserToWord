namespace ParserForKursach;

public class Settings
{
    public List<string> FormatsOfFiles { get; set; } = new List<string>
    {
        "*.cs",
        "*.xaml",
        "*.cshtml"
    };
}