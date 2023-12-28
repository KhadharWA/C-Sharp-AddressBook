using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Interfaces;
using Shared.Models;

using System.Diagnostics;



namespace ConnectHub.ViewModels;

public partial class AddViewModel : ObservableObject
{
    private readonly IPersonRepository _personRepository;

    /// <summary>
    /// Initializes a new instance of the AddViewModel class.
    /// </summary>
    /// <param name="personRepository">Repository for handling person data operations.</param>
    public AddViewModel(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
        
    }

    /// <summary>
    /// Holds the form data for a new person registration.
    /// </summary>
    [ObservableProperty]
    private Person _registrationForm = new();


    /// <summary>
    /// Adds the content of the registration form to the person list and navigates to the persons list page.
    /// </summary>
    [RelayCommand]
    public async Task AddContentToList()
    {
        if (RegistrationForm != null && !string.IsNullOrWhiteSpace(RegistrationForm.Email)) 
        {
            var result = _personRepository.AddPersonToList(RegistrationForm);
            if (result)
            {
                
                RegistrationForm = new ();


                try
                {
                    await Shell.Current.GoToAsync("//PersonsListPage");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Navigation error: {ex.Message}");
                }
            }
            else
            {
                
                Debug.WriteLine("Failed to add person to the list.");
            }
        }
    }

    
    
}
