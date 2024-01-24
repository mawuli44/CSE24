using System.Security.Cryptography.X509Certificates;

public class word
{

  public string _text;
  public bool _isHidden;

  public word(string _text)
 {
  _text = text;
  _isHidden = false;
 }
 public void Hide()
 {
    _isHidden = true;
  }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}




