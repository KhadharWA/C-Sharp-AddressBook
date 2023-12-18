

namespace Shared.Interfaces;

public interface IPersonRepository
{

    event EventHandler PersonListUpdated;

    bool AddPersonToList(IPerson person);

    bool RemovePersonFromList(string email);

    bool UpdatePerson(IPerson updatedPerson);

    IEnumerable<IPerson> GetPersonsFromList();

    IPerson GetPersonByEmail(string email);
}
