using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Interfaces;
using Shared.Models;
using System.Collections.ObjectModel;


namespace ConnectHub.ViewModels;

public partial class AddViewModel : ObservableObject
{
    private readonly IPersonRepository _personRepository;

    public AddViewModel(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    [ObservableProperty]
    private Person _registrationForm = new();

    [ObservableProperty]
    private ObservableCollection<IPerson> _personsList = new ObservableCollection<IPerson>(Enumerable.Empty<IPerson>());

    [RelayCommand]
    public void AddContentToList()
    {
        if (RegistrationForm != null && !string.IsNullOrWhiteSpace(RegistrationForm.Email))
        {
            var result = _personRepository.AddPersonToList(RegistrationForm);
            if (result)
            {
                UpdateCustomerList();
                RegistrationForm = new();
            }
        }
    }

    public void UpdateCustomerList()
    {
        PersonsList = new ObservableCollection<IPerson>(_personRepository.GetPersonsFromList());
    }
}
