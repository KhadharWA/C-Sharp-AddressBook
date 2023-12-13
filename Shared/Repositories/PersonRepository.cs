

using Newtonsoft.Json;
using Shared.Interfaces;
using Shared.Services;
using System.Diagnostics;

namespace Shared.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly IFileService _fileService;

    public PersonRepository(IFileService fileService)
    {
        _fileService = fileService;
    }

    public List<IPerson> _personsList = [];
    private readonly string _filePath = @"c:\utb-Projects\AdressBook\contacts.json";


    public bool AddPersonToList(IPerson person)
    {
        try
        {
            if (!_personsList.Any(x => x.Email == person.Email))
            {
                _personsList.Add(person);

                string json = JsonConvert.SerializeObject(_personsList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

                var result = _fileService.SaveContectToFile(_filePath, json);
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

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
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

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
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    private void SavePersonsListToFile()
    {
        string json = JsonConvert.SerializeObject(_personsList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
        _fileService.SaveContectToFile(_filePath, json);
    }


}
