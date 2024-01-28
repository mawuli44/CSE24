using System;


        // Word class.cs
public class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public override string ToString()
    {
        return IsHidden ? "_____" : Text;
    }
}

// Reference class.cs
public class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int EndVerse { get; }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}

// Scripture class.cs
public class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        InitializeWords(text);
    }

    private void InitializeWords(string text)
    {
        string[] wordArray = text.Split(' ');
        words = wordArray.Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine(reference.ToString());
        foreach (var word in words)
        {
            Console.Write(word.ToString() + " ");
        }
        Console.WriteLine();
    }

    public bool HideRandomWords()
    {
        List<Word> visibleWords = words.Where(word => !word.IsHidden).ToList();
        if (visibleWords.Count == 0)
        {
            return false; 
        }

        Random random = new Random();
        int index = random.Next(visibleWords.Count);
        visibleWords[index].IsHidden = true;
        return true;
    }
  // Program.cs
class Program
{
     static void Main(string[] args)   
    {
        // Example usage
        Reference reference = new Reference("John", 3, 16, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        bool wordsHidden = true;
        while (wordsHidden)
        {
            Console.Clear();
            scripture.Display();

            Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            wordsHidden = scripture.HideRandomWords();
        }
    }