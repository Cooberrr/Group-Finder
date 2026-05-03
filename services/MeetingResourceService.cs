namespace GroupMe.services;

using GroupMe.contracts;

public class MeetingResourceService : IFileStorage
{
    private Dictionary<string, string> _files;

    public MeetingResourceService()
    {
        _files = new Dictionary<string, string>();
    }

    public void UploadFile(string fileName, string content)
    {
        _files[fileName] = content;
        Console.WriteLine($"'{fileName}' uploaded.");
    }

    public string GetFile(string fileName)
    {
        if (_files.ContainsKey(fileName))
        {
            return _files[fileName];
        }

        return "File not found.";
    }

    public List<string> ListFiles()
    {
        return _files.Keys.ToList();
    }

    public void DeleteFile(string fileName)
    {
        if (_files.Remove(fileName))
        {
            Console.WriteLine($"'{fileName}' deleted.");
        }
    }
}