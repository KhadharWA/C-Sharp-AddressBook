

namespace Shared.Interfaces;


/// <summary>
/// Defines a contract for a repository managing persons.
/// </summary>
public interface IPersonRepository
{
    /// <summary>
    /// Occurs when the persons list is updated.
    /// </summary>
    event EventHandler PersonsListUpdated;


    /// <summary>
    /// Adds a person to the repository.
    /// </summary>
    /// <param name="person">The person to add.</param>
    /// <returns>True if the person was successfully added, false otherwise.</returns>
    bool AddPersonToList(IPerson person);


    /// <summary>
    /// Removes a person from the repository by email.
    /// </summary>
    /// <param name="email">The email of the person to remove.</param>
    /// <returns>True if the person was successfully removed, false otherwise.</returns>
    bool RemovePersonFromList(string email);


    /// <summary>
    /// Updates the details of a person in the repository.
    /// </summary>
    /// <param name="updatedPerson">The person with updated details.</param>
    /// <returns>True if the person was successfully updated, false otherwise.</returns>
    bool UpdatePerson(IPerson updatedPerson);


    /// <summary>
    /// Retrieves all persons from the repository.
    /// </summary>
    /// <returns>An enumerable of all persons in the repository.</returns>
    IEnumerable<IPerson> GetPersonsFromList();


    /// <summary>
    /// Retrieves a person from the repository by their email.
    /// </summary>
    /// <param name="email">The email of the person to retrieve.</param>
    /// <returns>The person if found, otherwise null.</returns>
    IPerson GetPersonByEmail(string email);
}
