using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Interfaces;
using Shared.Models;
using System.Collections.ObjectModel;
namespace ConnectHub.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IPersonRepository _personRepository;

    public MainViewModel(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
        
    }

    [ObservableProperty]
    private Person _registrationForm = new();

    [ObservableProperty]
    private ObservableCollection<IPerson> _personsList = [];

    [RelayCommand]
    public void AddContentToList ()
    {
        if (RegistrationForm != null && !string.IsNullOrWhiteSpace(RegistrationForm.Email)) 
        {
            var result = _personRepository.AddPersonToList(RegistrationForm);
            if (result) 
            {
                PersonsList = (ObservableCollection<IPerson>)_personRepository.GetPersonsFromList();
            }
        }
    }

    public void UpdateCustomerList () 
    {
        PersonsList = new ObservableCollection<IPerson>(_personRepository.GetPersonsFromList());
    
    }
}
