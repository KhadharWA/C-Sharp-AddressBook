

namespace Shared.Interfaces;


/// <summary>
/// Defines the contract for a service handling file operations.
/// </summary>
public interface IFileService
{
    bool SaveContectToFile(string filePath, string content);

    string GetContentFromFile(string filePath);
}
