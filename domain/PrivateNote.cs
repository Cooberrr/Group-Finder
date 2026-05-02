namespace GroupMe.domain;

public class PrivateNote : Note
{
    private List<User> _allowedUsers;

    public PrivateNote(int noteId, string title, string content, User owner)
        : base(noteId, title, content)
    {
        _allowedUsers = new List<User> { owner };
    }

    public void AllowAccess(User user)
    {
        if (!_allowedUsers.Contains(user))
        {
            _allowedUsers.Add(user);
            Console.WriteLine($"{user.Name} can look at '{Title}'.");
        }
    }

    public override bool IsVisible(User user)
    {
        return _allowedUsers.Contains(user);
    }
}