namespace GroupMe.domain;
using GroupMe.contracts;

public class CalendarService : ICalendar
{
    private List<Meeting> _meetings;
 
    public CalendarService()
    {
        _meetings = new List<Meeting>();
    }
 
    public void AddMeeting(Meeting meeting)
    {
        _meetings.Add(meeting);
        Console.WriteLine($" '{meeting.GetDetails().Title}' added to calendar.");
    }
 
    public void RemoveMeeting(Meeting meeting)
    {
        if (_meetings.Remove(meeting))
        {
            Console.WriteLine($" '{meeting.GetDetails().Title}' removed from calendar.");
        }
    }
    public List<Meeting> GetMeetings()
    {
        return _meetings;
    }
}