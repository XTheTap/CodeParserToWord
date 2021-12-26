namespace ParserForKursach;

public class FilePathSettings
{
    public List<string> FormatsOfFiles { get; set; } = new List<string>
    {
        "*.cs",
        "*.xaml",
        "*.cshtml"
    };
}