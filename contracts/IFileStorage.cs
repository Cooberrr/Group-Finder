namespace GroupMe.contracts;

public interface IFileStorage
{
    void UploadFile(string fileName, string content);
    string GetFile(string fileName);
    List<string> ListFiles();
    void DeleteFile(string fileName);
}