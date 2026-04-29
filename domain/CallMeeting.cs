namespace GroupMe.domain;

public class CallMeeting : Meeting
{
    private int _conferenceNum;

    public CallMeeting(MeetingDetails details, int conferenceNum)
        : base(details)
    {
        _conferenceNum = conferenceNum;
    }

    public override void StartMeeting()
    {
        Console.WriteLine($"Starting call meeting: {Details.Title}");
        Console.WriteLine($"Conference number: {_conferenceNum}");
    }
}