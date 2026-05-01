namespace GroupMe.domain;

public abstract class Note
{
    public int NoteId { get; private set; }
    public string Title { get; private set; }
    protected string Content { get; set; }
    
    public Note(int noteId, string title, string content)
    {
        NoteId = noteId;
        Title = title;
        Content = content;
    }
    public virtual void Edit(string newContent)
    {
        Content = newContent;
        Console.WriteLine($"Note '{Title}' updated.");
    }
    public string GetContent()
    {
        return Content;
    }
 
    public void Share(List<User> members)
    {
        foreach (User member in members)
        {
            Console.WriteLine($"Note '{Title}' shared with {member.Name}.");
        }
    }
    public abstract bool IsVisible(User user);
}