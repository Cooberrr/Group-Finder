namespace GroupMe.domain;

public class GroupMember : User
{
    private Group _group;
    private List<Note> _notes;
    
    public GroupMember(int userId, string name, string email, Role role) 
        : base(userId, name, email, role)
    {
        _notes = new List<Note>();
    }
    
    
    
    public void MeetingReply(string reply)
    {
        Console.WriteLine($"{Name} replied to meeting: {reply}");
    }
    
    public void ViewNote(string fileName)
    {
        Console.WriteLine($"{Name} viewing note: {fileName}");
    }
    
    public void CreateNote(string fileName)
    {
        Console.WriteLine($"{Name} created note: {fileName}");
    }
    
    public void UploadNote(string fileName)
    {
        Console.WriteLine($"{Name} uploaded note: {fileName}");
    }
    
    public void ViewFile(string fileName)
    {
        Console.WriteLine($"{Name} viewing file: {fileName}");
    }
    
    public void CreateFile(string fileName)
    {
        Console.WriteLine($"{Name} created file: {fileName}");
    }
    
    public void UploadFile(string fileName)
    {
        Console.WriteLine($"{Name} uploaded file: {fileName}");
    }
    
    public void InviteToGroup(int userId)
    {
        Console.WriteLine($"{Name} invited user {userId} ");
    }
    
}