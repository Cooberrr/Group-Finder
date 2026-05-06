using GroupMe.domain;
using GroupMe.services;

namespace GroupMe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("GroupMe rough draft test running...");

            CalendarService calendar = new CalendarService();

            MeetingDetails details = new MeetingDetails(
                "Project Meeting",
                DateTime.Now,
                MeetingType.Online
            );

            calendar.CreateAndAddMeeting(
                MeetingType.Online,
                details,
                link: "zoom.com/test"
            );

            foreach (Meeting meeting in calendar.GetMeetings())
            {
                meeting.StartMeeting();
            }

            NoteService noteService = new NoteService();

            PublicNote note = new PublicNote(
                1,
                "Sprint Notes",
                "Work on UML and interfaces."
            );

            noteService.CreateNotes(note);

            foreach (Note savedNote in noteService.GetNotes())
            {
                Console.WriteLine(savedNote.Title);
            }

            MeetingResourceService fileService = new MeetingResourceService();

            fileService.UploadFile("uml-draft.png", "fake file data");

            foreach (string file in fileService.ListFiles())
            {
                Console.WriteLine(file);
            }

            ConsoleUI UI = new ConsoleUI();
            UI.ShowMenu();
        }
    }
}