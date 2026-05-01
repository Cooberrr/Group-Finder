namespace GroupMe.domain;

public class User
{
    public int UserID { get; private set; }
    public string Name  { get; private set; }
    public string Email { get; private set; }
    public Role Role { get; private set; }

    public User(int userId, string name, string emain, string role)
    {
        UserID = userId;
        Name = name;
        Email = emain;
        Role = role;
    }

    // virtual so if prossefor and groupLeader has specail join permissions
    public virtual void JoinGroup(Group group)
    {
        group.AddMember(this)
    }
}

