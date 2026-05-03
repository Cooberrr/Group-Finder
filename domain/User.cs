namespace GroupMe.domain;

public class User
{
    public int UserID { get; private set; }
    public string Name  { get; private set; }
    public string Email { get; private set; }
    public Role Role { get; private set; }

    public User(int userId, string name, string email, Role role)
    {
        UserID = userId;
        Name = name;
        Email = email;
        Role = role;
    }

    // virtual so if prossefor and groupLeader has specail join permissions
    public virtual void JoinGroup(Group group)
    {
        if (this is GroupMember member)
        {
            group.AddMember(member);
        }
    }
}

