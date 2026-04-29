namespace GroupMe.contracts;

using GroupMe.domain;

public interface ICalendar
{
    void AddMeeting(Meeting meeting);
    void RemoveMeeting(Meeting meeting);
    List<Meeting> GetMeetings();
}