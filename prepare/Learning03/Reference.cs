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
