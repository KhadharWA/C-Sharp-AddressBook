

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Interfaces;
using Shared.Models;
using System.Collections.ObjectModel;

namespace ConnectHub.ViewModels;

public partial class ShowViewModel : ObservableObject
{
    private readonly IPersonRepository _personRepository;

    public ShowViewModel(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
        EmailInput = string.Empty;
        SelectPerson();
    }

    [ObservableProperty]
    private IPerson? _selectedPerson;

    [ObservableProperty]
    private string _emailInput;

    [ObservableProperty]
    private ObservableCollection<IPerson> _personsList = [];


    [RelayCommand]
    public void SelectPerson()
    {
        if (!string.IsNullOrWhiteSpace(EmailInput))
        {
            SelectedPerson = _personRepository.GetPersonByEmail(EmailInput);
            EmailInput = string.Empty;
            PersonsList = new ObservableCollection<IPerson>(_personRepository.GetPersonsFromList());
        }
    }

    
}
