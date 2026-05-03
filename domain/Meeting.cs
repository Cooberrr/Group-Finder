namespace GroupMe.domain;

public abstract class Meeting
{
    protected MeetingDetails Details;
    protected List<GroupMember> Attendees;

    public Meeting(MeetingDetails details)
    {
        Details = details;
        Attendees = new List<GroupMember>();
    }

    public virtual void StartMeeting()
    {
        Console.WriteLine($"Starting meeting: {Details.Title}");
    }

    public virtual void EndMeeting()
    {
        Console.WriteLine($"Ending meeting: {Details.Title}");
    }

    public void AddAttendee(GroupMember member)
    {
        if (!Attendees.Contains(member))
        {
            Attendees.Add(member);
        }
    }

    public List<GroupMember> ShowAttendees()
    {
        return Attendees;
    }

    public MeetingDetails GetDetails()
    {
        return Details;
    }
}