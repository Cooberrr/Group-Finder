namespace GroupMe.domain;

public class Group
{
    public int GroupId { get; private set; }
    public string GroupName { get; private set; }
    
    private List<GroupMember> _members;
    private List<Note> _notes;
    private List<Meeting> _meetings;
    
    public Group(int groupId, string groupName)
    {
        GroupId = groupId;
        GroupName = groupName;
        _members = new List<GroupMember>();
        _notes = new List<Note>();
        _meetings = new List<Meeting>();
    }
    
    public void AddMember(GroupMember member)
    {
        if (!_members.Contains(member))
        {
            _members.Add(member);
            Console.WriteLine($"{member.Name} added to {GroupName}.");
        }
    }
    
    public void RemoveMember(GroupMember member)
    {
        if (_members.Remove(member))
        {
            Console.WriteLine($"{member.Name} removed from {GroupName}.");
        }
    }
    
    public List<GroupMember> GetMembers()
    {
        return _members;
    }
    
    public List<Note> GetNotes()
    {
        return _notes;
    }
    
    public void AddNote(Note note)
    {
        _notes.Add(note);
    }
    
    public List<Meeting> GetMeetings()
    {
        return _meetings;
    }
    
    public void AddMeeting(Meeting meeting)
    {
        _meetings.Add(meeting);
    }

}