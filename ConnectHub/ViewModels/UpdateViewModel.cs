

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Interfaces;
using Shared.Models;
using Shared.Repositories;

namespace ConnectHub.ViewModels;

public partial class UpdateViewModel : ObservableObject, IQueryAttributable
{
    private readonly IPersonRepository _personRepository;

    public UpdateViewModel(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    [ObservableProperty]
    private Person person = new();

    [RelayCommand]
    public async Task Update()
    {
        _personRepository.UpdatePerson(Person); 
        Person = new ();
        await Shell.Current.GoToAsync("//PersonsListPage");
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Person = (query["Update"] as Person)!;
    }
}
