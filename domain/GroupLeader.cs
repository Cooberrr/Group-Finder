namespace GroupMe.domain;

public class GroupLeader : GroupMember
{
    private List<GroupMember> _assignedMembers;
    
    public GroupLeader(int userId, string name, string email)
        : base(userId, name, email, Role.GroupLeader)
    {
        _assignedMembers = new List<GroupMember>();
    }
    
    public void ApproveMeeting(Meeting meeting)
    {
        Console.WriteLine($"{Name} approved meeting: {meeting.Title}");
    }
    
    public void AssignTask(GroupMember member)
    {
        if (!_assignedMembers.Contains(member))
        {
            _assignedMembers.Add(member);
        }
        Console.WriteLine($"{Name} assigned task to {member.Name} ");
    }
    
    public List<GroupMember> GetAssignedMembers()
    {
        return _assignedMembers;
    }
}