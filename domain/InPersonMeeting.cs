namespace GroupMe.domain;

public class InPersonMeeting : Meeting
{
    private string _location;

    public InPersonMeeting(MeetingDetails details, string location)
        : base(details)
    {
        _location = location;
    }

    public override void StartMeeting()
    {
        Console.WriteLine($"Starting in-person meeting: {Details.Title}");
        Console.WriteLine($"Location: {_location}");
    }
}