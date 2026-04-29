namespace GroupMe.domain;

public class OnlineMeeting : Meeting
{
    private string _link;

    public OnlineMeeting(MeetingDetails details, string link)
        : base(details)
    {
        _link = link;
    }

    public override void StartMeeting()
    {
        Console.WriteLine($"Starting online meeting: {Details.Title}");
        Console.WriteLine($"Link: {_link}");
    }
}