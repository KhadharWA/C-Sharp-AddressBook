

using Shared.Interfaces;
using Shared.Services;

namespace ConsoleApp.Tests;

public class FileService_Tests
{
    [Fact]
    public void SaveToFileShould_ThenRetunTrue_IfFilePathDoExists()
    {
        //Arrange
        IFileService fileService = new FileService();
        string filePath = @"c:\utb-Projects\AdressBook\test.txt";
        string content = "Test content";
        //Act
        bool result = fileService.SaveContectToFile(filePath, content);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void SaveToFileShould_ThenRetunFalse_IfFilePathDoNotExists()
    {
        //Arrange
        IFileService fileService = new FileService();
        string filePath = @$"c:\{Guid.NewGuid()}\test.txt";
        string content = "Test content";
        //Act
        bool result = fileService.SaveContectToFile(filePath, content);

        //Assert
        Assert.False(result);
    }
}
