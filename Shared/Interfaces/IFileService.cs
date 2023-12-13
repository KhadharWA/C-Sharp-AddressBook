

namespace Shared.Interfaces;

public  interface IFileService
{
    bool SaveContectToFile(string filePath, string content);

    string GetContentFromFile(string filePath);
}
