public class Scripture
{
    public Reference _reference;
    public List<Word> _words;

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
    {
        return _words.All(word => word.IsHidden());
    }

    public List<Word> InitializeWords(string scriptureText);
    }
}