using System;
using System.Collections.Generic;
using System.Text;

class Document
{
    private List<string> parts = new List<string>();
    private List<string> footnotes = new List<string>();

    public void AddHeading(string text)
    {
        parts.Add("=== " + text + " ===");
    }

    public void AddSection(string text)
    {
        parts.Add(text);
    }

    public void AddFootnote(string text)
    {
        footnotes.Add(text);
    }

    public string GetContent()
    {
        StringBuilder sb = new StringBuilder();

        foreach (string part in parts)
            sb.AppendLine(part);

        if (footnotes.Count > 0)
        {
            sb.AppendLine();
            sb.AppendLine("Виноски:");
            foreach (string note in footnotes)
                sb.AppendLine("- " + note);
        }

        return sb.ToString();
    }
}

interface IDocumentBuilder
{
    void AddHeading(string text);
    void AddSection(string text);
    void AddFootnote(string text);
    Document GetDocument();
    void Reset();
}

class HtmlDocumentBuilder : IDocumentBuilder
{
    private Document document = new Document();

    public void Reset()
    {
        document = new Document();
    }

    public void AddHeading(string text)
    {
        document.AddHeading(text);
    }

    public void AddSection(string text)
    {
        document.AddSection(text);
    }

    public void AddFootnote(string text)
    {
        document.AddFootnote(text);
    }

    public Document GetDocument()
    {
        return document;
    }
}

class DocumentDirector
{
    public void ConstructTechnicalReport(IDocumentBuilder builder)
    {
        builder.Reset();

        builder.AddHeading("Технічний звіт");
        builder.AddSection("Це вступна секція технічного документа.");
        builder.AddFootnote("Дані взяті з відкритих джерел.");
        builder.AddSection("Опис основної архітектури системи.");
        builder.AddHeading("Висновок");
        builder.AddSection("Система працює стабільно.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IDocumentBuilder builder = new HtmlDocumentBuilder();
        DocumentDirector director = new DocumentDirector();

        Console.WriteLine("Generating Document...\n");

        director.ConstructTechnicalReport(builder);
        Document doc = builder.GetDocument();
        Console.WriteLine(doc.GetContent());

        Console.WriteLine("\nGenerating Custom Document...\n");

        builder.Reset();
        builder.AddHeading("Мій власний документ");
        builder.AddSection("Довільний текст секції.");
        builder.AddFootnote("Примітка автора.");

        Document customDoc = builder.GetDocument();
        Console.WriteLine(customDoc.GetContent());
    }
}
