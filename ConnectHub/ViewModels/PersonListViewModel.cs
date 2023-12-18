using CommunityToolkit.Mvvm.ComponentModel;
using Shared.Interfaces;
using System.Collections.ObjectModel;


namespace ConnectHub.ViewModels;

public partial class PersonListViewModel : ObservableObject
{
    private readonly IPersonRepository _personRepository;

    public PersonListViewModel(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
        _personRepository.PersonListUpdated += (sender, e) =>
        {
            RefreshPersonsList();
        };

        

    }

    [ObservableProperty]
    private ObservableCollection<IPerson> _personsList = new ObservableCollection<IPerson>();

    

    private void RefreshPersonsList()
    {
        var result = _personRepository.GetPersonsFromList();
        if (result != null)
        {
            PersonsList = new ObservableCollection<IPerson>(result);
        }
    }
}
