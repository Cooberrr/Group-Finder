namespace GroupMe.services;

using GroupMe.contracts;
using GroupMe.domain;
using GroupMe.factories;

public class CalendarService : ICalendar
{
    private List<Meeting> _meetings = new();

    public void AddMeeting(Meeting meeting)
    {
        _meetings.Add(meeting);
    }

    public void RemoveMeeting(Meeting meeting)
    {
        _meetings.Remove(meeting);
    }

    public List<Meeting> GetMeetings()
    {
        return _meetings;
    }

    public void CreateAndAddMeeting(
        MeetingType type,
        MeetingDetails details,
        string? link = null,
        string? location = null,
        int conferenceNum = 0)
    {
        Meeting meeting = MeetingFactory.CreateMeeting(
            type, details, link, location, conferenceNum
        );

        _meetings.Add(meeting);
    }
}