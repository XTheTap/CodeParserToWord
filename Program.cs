using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using ParserForKursach;

var settings = new FilePathSettings();

var workingDirectory = Environment.CurrentDirectory;

Console.WriteLine($"Братья работают по: {workingDirectory}");

var filepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Code.docx";

using var wordDocument = WordprocessingDocument.Create(filepath, WordprocessingDocumentType.Document);
var mainPart = wordDocument.AddMainDocumentPart();
mainPart.Document = new Document();
var body = mainPart.Document.AppendChild(new Body());
var para = body.AppendChild(new Paragraph());
var run = para.AppendChild(new Run());

foreach (var response in settings.FormatsOfFiles.Select(i => Directory.GetFiles(workingDirectory, i, SearchOption.AllDirectories)))
{
    foreach (var i in response)
    {
        Console.WriteLine($"Чтение по папке: {i}");
        using var streamReader = new StreamReader(i);

        var splitText = streamReader.ReadToEnd().Split('\n');

        foreach (var j in splitText)
        {
            run?.AppendChild(new Text(j));   
            run?.AppendChild(new Break());
        }
        
        run?.AppendChild(new Break());
    }
}

wordDocument.Close();