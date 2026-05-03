namespace GroupMe.domain;

public struct MeetingDetails
{
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public MeetingType Type { get; set; }

    public MeetingDetails(string title, DateTime date, MeetingType type)
    {
        Title = title;
        Date = date;
        Type = type;
    }
}