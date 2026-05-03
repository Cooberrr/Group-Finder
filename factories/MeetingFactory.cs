namespace GroupMe.factories;

using GroupMe.domain;

public class MeetingFactory
{
    public static Meeting CreateMeeting(
        MeetingType type,
        MeetingDetails details,
        string? link = null,
        string? location = null,
        int conferenceNum = 0)
    {
        switch (type)
        {
            case MeetingType.Online:
                return new OnlineMeeting(details, link ?? "No Link");

            case MeetingType.InPerson:
                return new InPersonMeeting(details, location ?? "No Location");

            case MeetingType.Hybrid:
                return new HybridMeeting(details, link ?? "No Link", location ?? "No Location");

            case MeetingType.Call:
                return new CallMeeting(details, conferenceNum);

            default:
                throw new Exception("Invalid meeting type");
        }
    }
}