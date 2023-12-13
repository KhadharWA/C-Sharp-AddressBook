

using Moq;
using Newtonsoft.Json;
using Shared.Interfaces;
using Shared.Models;
using Shared.Repositories;

namespace ConsoleApp.Tests;

public class PersonRepository_Tests
{
    [Fact]
    public void AddToListShould_AddonePersonToPersonList_ThenReturnTrue()
    {
        //Arrange
        IPerson person = new Person { FirstName = "Khadhar", LastName = "Abdulrazzaq", Email = "Khadhar@domain.com", PhoneNumber= "0735353535", Address = "Kristianstad" };
        
        var mockFileService = new Mock<IFileService>();
        mockFileService.Setup(x => x.SaveContectToFile(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        IPersonRepository personRepository = new PersonRepository(mockFileService.Object);

        // Act
        bool result = personRepository.AddPersonToList(person);

        //Assert
        Assert.True(result);// Check if the person was successfully Added
    }

    [Fact]
    public void GetAllFromListShould_GetAllPersonsInPersonList_ThenReturnListOfPerson()
    {
        // Arrange

        var persons = new List<IPerson> { new Person { FirstName = "Khadhar", LastName = "Abdulrazzaq", Email = "Khadhar@domain.com", PhoneNumber = "0735353535", Address = "Kristianstad" } };
        string json = JsonConvert.SerializeObject(persons, Formatting.None, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects});

        var mockFileService = new Mock<IFileService>();
        mockFileService.Setup(x => x.GetContentFromFile(It.IsAny<string>())).Returns(json);
        IPersonRepository personRepository = new PersonRepository(mockFileService.Object);

        // Act
        IEnumerable<IPerson> result = personRepository.GetPersonsFromList();

        // Assert
        Assert.NotNull(persons); // Check if the returned list is not null
        Assert.IsAssignableFrom<IEnumerable<IPerson>>(persons); // Check if the returned value is a list of IPerson
        Assert.NotEmpty(persons); // Check if the returned list is not empty
    }

    [Fact]
    public void RemoveFromListShould_RemovePersonFromPersonList_ThenReturnTrue()
    {
        // Arrange
        var mockFileService = new Mock<IFileService>();
        IPersonRepository personRepository = new PersonRepository(mockFileService.Object);
        IPerson person = new Person { FirstName = "Khadhar", LastName = "Abdulrazzaq", Email = "Khadhar@domain.com", PhoneNumber = "0735353535", Address = "Kristianstad" };
        personRepository.AddPersonToList(person);

        // Act
        bool result = personRepository.RemovePersonFromList("Khadhar@domain.com");

        // Assert
        Assert.True(result); // Check if the person was successfully removed
    }

    [Fact]
    public void GetPersonByEmail_ShouldReturnCorrectPerson()
    {
        // Arrange
        var mockFileService = new Mock<IFileService>();
        IPersonRepository personRepository = new PersonRepository(mockFileService.Object);
        IPerson person = new Person { FirstName = "Khadhar", LastName = "Abdulrazzaq", Email = "Khadhar@domain.com", PhoneNumber = "0735353535", Address = "Kristianstad" };
        personRepository.AddPersonToList(person);

        // Act
        var retrievedPerson = personRepository.GetPersonByEmail("Khadhar@domain.com");

        // Assert
        Assert.NotNull(retrievedPerson);
        Assert.Equal("Khadhar", retrievedPerson.FirstName);
        Assert.Equal("Abdulrazzaq", retrievedPerson.LastName);
        Assert.Equal("Khadhar@domain.com", retrievedPerson.Email);
        Assert.Equal("0735353535", retrievedPerson.PhoneNumber);
        Assert.Equal("Kristianstad", retrievedPerson.Address);
    }



    [Fact]
    public void UpdatePersonShould_UpdateExistingPerson_ThenReturnTrue()
    {
        // Arrange
        var mockFileService = new Mock<IFileService>();
        IPersonRepository personRepository = new PersonRepository(mockFileService.Object);
        IPerson person = new Person { FirstName = "Khadhar", LastName = "Abdulrazzaq", Email = "Khadhar@domain.com", PhoneNumber = "0735353535", Address = "Kristianstad" };
        personRepository.AddPersonToList(person);

        // Create an updated version of the person
        IPerson updatedPerson = new Person { FirstName = "Khadhar", LastName = "Abdulrazzaq", Email = "Khadhar@domain.com", PhoneNumber = "0735792009", Address = "Kristianstad" };

        // Act
        bool result = personRepository.UpdatePerson(updatedPerson);

        // Assert
        Assert.True(result); // Check if the person was successfully updated
    }
}
