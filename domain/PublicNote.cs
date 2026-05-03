namespace GroupMe.domain;

public class PublicNote : Note
{
    public PublicNote(int noteId, string title, string content)
        : base(noteId, title, content)
    {
    }
    public override bool IsVisible(User user)
    {
        return true;
    }
    
}