namespace GroupMe.domain;

using GroupMe.contracts;

public class NoteService : IMeetingNotes
{
    private List<Note> _notes;
 
    public NotesService()
    {
        _notes = new List<Note>();
    }
 
    public void CreateNotes(Note note)
    {
        _notes.Add(note);
        Console.WriteLine($" '{note.Title}' created.");
    }
 
    public void EditNotes(Note note)
    {
        Console.WriteLine($" '{note.Title}' is ready to edit.");
    }
 
    public List<Note> GetNotes()
    {
        return _notes;
    }
    
}