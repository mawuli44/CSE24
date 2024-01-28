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
            return false; // All words are hidden
        }

        Random random = new Random();
        int index = random.Next(visibleWords.Count);
        visibleWords[index].IsHidden = true;
        return true;
    }
}
