namespace GroupMe.domain;

using GroupMe.services;
using GroupMe.factories;

public class ConsoleUI
{
    private CalendarService _calendar;
    private NoteService _noteService;
    private MeetingResourceService _fileService;
    private Group _group;
    private GroupLeader _leader;
    public ConsoleUI()
    {
        _calendar = new CalendarService();
        _noteService = new NoteService();
        _fileService = new MeetingResourceService();
    }

    public void ShowMenu()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== GroupMe Main Menu ===");
            Console.WriteLine("1. Setup Group");
            Console.WriteLine("2. Schedule a Meeting");
            Console.WriteLine("3. View Meetings");
            Console.WriteLine("4. Create a Note");
            Console.WriteLine("5. View Notes");
            Console.WriteLine("6. Upload a File");
            Console.WriteLine("7. View Files");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            int choice = ReadChoice();

            switch (choice)
            {
                case 1:
                    SetupGroup();
                    break;
                case 2:
                    ScheduleMeeting();
                    break;
                case 3:
                    ViewMeetings();
                    break;
                case 4:
                    CreateNote();
                    break;
                case 5:
                    ViewNotes();
                    break;
                case 6:
                    UploadFile();
                    break;
                case 7:
                    ViewFiles();
                    break;
                case 0:
                    running = false;
                    DisplayMessage("Goodbye!");
                    break;
                default:
                    DisplayMessage("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public int ReadChoice()
    {
        string input = Console.ReadLine() ?? "0";
        if (int.TryParse(input, out int choice))
        {
            return choice;
        }
        return -1;
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine($"\n{message}");
    }

    private void SetupGroup()
    {
        Console.Write("Enter group name: ");
        string groupName = Console.ReadLine() ?? "My Group";

        _group = new Group(1, groupName);
        Console.Write("Enter leader name: ");
        string leaderName = Console.ReadLine() ?? "Leader";

        Console.Write("Enter leader email: ");
        string leaderEmail = Console.ReadLine() ?? "leader@email.com";

        _leader = new GroupLeader(1, leaderName, leaderEmail);
        _leader.JoinGroup(_group);
        DisplayMessage($"Group '{groupName}' created with leader {leaderName}.");
    }

    private void ScheduleMeeting()
    {
        if (_group == null)
        {
            DisplayMessage("Please set up a group first (Option 1).");
            return;
        }
        Console.Write("Enter meeting title: ");
        string title = Console.ReadLine() ?? "Meeting";

        Console.WriteLine("Select meeting type:");
        Console.WriteLine("1. Online  2. InPerson  3. Hybrid  4. Call");
        int typeChoice = ReadChoice();

        MeetingType type = typeChoice switch
        {
            1 => MeetingType.Online,
            2 => MeetingType.InPerson,
            3 => MeetingType.Hybrid,
            4 => MeetingType.Call,
            _ => MeetingType.Online
        };

        MeetingDetails details = new MeetingDetails(title, DateTime.Now, type);
        string? link = null;
        string? location = null;
        int conferenceNum = 0;

        if (type == MeetingType.Online || type == MeetingType.Hybrid)
        {
            Console.Write("Enter meeting link: ");
            link = Console.ReadLine();
        }
        if (type == MeetingType.InPerson || type == MeetingType.Hybrid)
        {
            Console.Write("Enter location: ");
            location = Console.ReadLine();
        }
        if (type == MeetingType.Call)
        {
            Console.Write("Enter conference number: ");
            int.TryParse(Console.ReadLine(), out conferenceNum);
        }

        _calendar.CreateAndAddMeeting(type, details, link, location, conferenceNum);
        DisplayMessage($"Meeting '{title}' scheduled.");
    }
    private void ViewMeetings()
    {
        List<Meeting> meetings = _calendar.GetMeetings();

        if (meetings.Count == 0)
        {
            DisplayMessage("No meetings scheduled.");
            return;
        }

        Console.WriteLine("\n=== Scheduled Meetings ===");
        foreach (Meeting m in meetings)
        {
            MeetingDetails d = m.GetDetails();
            Console.WriteLine($"- {d.Title} | {d.Type} | {d.Date:MM/dd/yyyy}");
        }
    }

    private void CreateNote()
    {
        Console.Write("Enter note title: ");
        string title = Console.ReadLine() ?? "Note";

        Console.Write("Enter note content: ");
        string content = Console.ReadLine() ?? "";

        Console.Write("Public or Private? (1 = Public, 2 = Private): ");
        int noteType = ReadChoice();

        Note note;

        if (noteType == 2 && _leader != null)
        {
            note = new PrivateNote(_noteService.GetNotes().Count + 1, title, content, _leader);
        }
        else
        {
            note = new PublicNote(_noteService.GetNotes().Count + 1, title, content);
        }

        _noteService.CreateNotes(note);
    }
    private void ViewNotes()
    {
        List<Note> notes = _noteService.GetNotes();

        if (notes.Count == 0)
        {
            DisplayMessage("No notes found.");
            return;
        }

        Console.WriteLine("\n=== Notes ===");
        foreach (Note n in notes)
        {
            Console.WriteLine($"- [{n.GetType().Name}] {n.Title}: {n.GetContent()}");
        }
    }

    private void UploadFile()
    {
        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine() ?? "file.txt";

        Console.Write("Enter file content: ");
        string content = Console.ReadLine() ?? "";

        _fileService.UploadFile(fileName, content);
    }

    private void ViewFiles()
    {
        List<string> files = _fileService.ListFiles();

        if (files.Count == 0)
        {
            DisplayMessage("No files uploaded.");
            return;
        }
        Console.WriteLine("\n=== Uploaded Files ===");
        foreach (string f in files)
        {
            Console.WriteLine($"-{f}");
        }
    }
}