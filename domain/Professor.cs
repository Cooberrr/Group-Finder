namespace GroupMe.domain;

public class Professor : GroupMember
{
    public Professor(int userId, string name, string email)
        : base(userId, name, email, Role.Professor)
    {
    }
    
    public void AddMemberToGroup(GroupMember member, Group group)
    {
        group.AddMember(member);
        Console.WriteLine($"{Name} added {member.Name} to the group.");
    }
    
    public void RemoveMemberFromGroup(GroupMember member, Group group)
    {
        group.RemoveMember(member);
        Console.WriteLine($"{Name} removed {member.Name} from the group.");
    }
}