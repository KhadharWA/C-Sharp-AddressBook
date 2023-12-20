using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Interfaces;
using Shared.Models;



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
        _personRepository.AddPersonToList(RegistrationForm);
        RegistrationForm = new();
        await Shell.Current.GoToAsync("..");
    }

    
}
