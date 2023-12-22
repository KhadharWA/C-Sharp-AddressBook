using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Interfaces;
using Shared.Models;

using System.Diagnostics;



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

    


    [RelayCommand]
    public async Task AddContentToList()
    {
        if (RegistrationForm != null && !string.IsNullOrWhiteSpace(RegistrationForm.Email)) 
        {
            var result = _personRepository.AddPersonToList(RegistrationForm);
            if (result)
            {
                _personRepository.AddPersonToList(RegistrationForm);
                RegistrationForm = new ();
                

                await Shell.Current.GoToAsync("//PersonsListPage");
            }
            else
            {
                
                Debug.WriteLine("Failed to add person to the list.");
            }
        }
    }

    
    
}
