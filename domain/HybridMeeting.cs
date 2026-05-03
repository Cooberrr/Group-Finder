namespace GroupMe.domain;

public class HybridMeeting : Meeting
{
    private string _link;
    private string _location;

    public HybridMeeting(MeetingDetails details, string link, string location)
        : base(details)
    {
        _link = link;
        _location = location;
    }

    public override void StartMeeting()
    {
        Console.WriteLine($"Starting hybrid meeting: {Details.Title}");
        Console.WriteLine($"Link: {_link}");
        Console.WriteLine($"Location: {_location}");
    }
}