

using Newtonsoft.Json;
using Shared.Interfaces;
using Shared.Services;
using System.Diagnostics;

namespace Shared.Repositories;


/// <summary>
/// A repository for managing person entities.
/// </summary>
public class PersonRepository : IPersonRepository
{
    private readonly IFileService _fileService;

    /// <summary>
    /// Initializes the repository with a file service dependency.
    /// </summary>
    /// <param name="fileService">Service for file operations.</param>
    public PersonRepository(IFileService fileService)
    {
        _fileService = fileService;
    }

    public List<IPerson> _personsList = [];
    private readonly string _filePath = @"c:\utb-Projects\AdressBook\contacts.json";
    public event EventHandler? PersonsListUpdated;





    /// <summary>
    /// Adds a new person to the list if not already present.
    /// </summary>
    /// <param name="person">Person to add.</param>
    /// <returns>True if the addition was successful, false otherwise.</returns>
    public bool AddPersonToList(IPerson person)
    {
        try
        {
            if (!_personsList.Any(x => x.Email == person.Email))
            {
                _personsList.Add(person);
                

                string json = JsonConvert.SerializeObject(_personsList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

                var result = _fileService.SaveContectToFile(_filePath, json);
                PersonsListUpdated?.Invoke(this, EventArgs.Empty);
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    /// <summary>
    /// Retrieves a person by their email address.
    /// </summary>
    /// <param name="email">Email of the person to find.</param>
    /// <returns>The person if found, null otherwise.</returns>
    public IPerson GetPersonByEmail(string email)
    {
        try
        {
            GetPersonsFromList();
            
            var person = _personsList.FirstOrDefault(x => x.Email == email);
            return person ??= null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }


    /// <summary>
    /// Loads and returns all persons from the list.
    /// </summary>
    /// <returns>An enumerable of persons.</returns>
    public IEnumerable<IPerson> GetPersonsFromList()
    {
        try
        {
            var content = _fileService.GetContentFromFile(_filePath);
            
            if (!string.IsNullOrEmpty(content))
            {
                
                _personsList = JsonConvert.DeserializeObject<List<IPerson>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return _personsList;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }



    /// <summary>
    /// Removes a person from the list by their email.
    /// </summary>
    /// <param name="email">Email of the person to remove.</param>
    /// <returns>True if removal was successful, false otherwise.</returns>
    public bool RemovePersonFromList(string email)
    {
        try
        {
            GetPersonsFromList();
            
            var personToRemove = _personsList.FirstOrDefault(x => x.Email == email);

            if (personToRemove != null)
            {
                _personsList.Remove(personToRemove);
                SavePersonsListToFile();
                PersonsListUpdated?.Invoke(this, EventArgs.Empty);
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }



    /// <summary>
    /// Updates the information of an existing person.
    /// </summary>
    /// <param name="updatedPerson">Person with updated information.</param>
    /// <returns>True if the update was successful, false otherwise.</returns>

    public bool UpdatePerson(IPerson updatedPerson)
    {
        try
        {
            GetPersonsFromList();
            
            var existingPerson = _personsList.FirstOrDefault(x => x.Email == updatedPerson.Email);

            if (existingPerson != null)
            {
                existingPerson.FirstName = updatedPerson.FirstName;
                existingPerson.LastName = updatedPerson.LastName;
                existingPerson.PhoneNumber = updatedPerson.PhoneNumber;
                existingPerson.Address = updatedPerson.Address;

                SavePersonsListToFile();
                PersonsListUpdated?.Invoke(this, EventArgs.Empty);
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }



    /// <summary>
    /// Saves the current list of persons to a file.
    /// </summary>
    private void SavePersonsListToFile()
    {
        string json = JsonConvert.SerializeObject(_personsList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
        _fileService.SaveContectToFile(_filePath, json);
    }


}
