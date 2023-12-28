using Shared.Interfaces;
using System.Diagnostics;


namespace Shared.Services;


/// <summary>
/// Provides file handling services, such as reading from and writing to files.
/// </summary>
public class FileService : IFileService
{

    /// <summary>
    /// Reads and returns the content of a file.
    /// </summary>
    /// <param name="filePath">The path of the file to read from.</param>
    /// <returns>The content of the file if it exists, otherwise null.</returns>
    public string GetContentFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }


    /// <summary>
    /// Saves the provided content to a file.
    /// </summary>
    /// <param name="filePath">The path of the file to save to.</param>
    /// <param name="content">The content to be written to the file.</param>
    /// <returns>True if the content was successfully saved, false otherwise.</returns>
    public bool SaveContectToFile(string filePath, string content)
    {
        try
        {
            using var sw = new StreamWriter(filePath, false);
            sw.WriteLine(content);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
