public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string scriptureText)
    {
        _reference = reference;
        _words = InitializeWords(scriptureText);
    }

    public void HideRandomWords(int numberToHide)
    {
    

    public string GetDisplayText()
    {

    public bool IsCompletelyHidden()

        return _words.All(word => word.IsHidden());
    }

    private List<Word> InitializeWords(string scriptureText)
    }
  }
}