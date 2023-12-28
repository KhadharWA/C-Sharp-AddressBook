using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Interfaces;
using System.Diagnostics;

namespace ConnectHub.ViewModels;

/// <summary>
/// ViewModel for displaying details of a person.
/// </summary>
public partial class ShowViewModel : ObservableObject
{
    private readonly IPersonRepository _personRepository;

    /// <summary>
    /// Initializes a new instance of the ShowViewModel class.
    /// </summary>
    /// <param name="personRepository">Repository for handling person data operations.</param>
    public ShowViewModel(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    /// <summary>
    /// Holds the details of the selected person.
    /// </summary>
    [ObservableProperty]
    private IPerson? _selectedPerson;

    /// <summary>
    /// Email of the person to be loaded.
    /// </summary>
    [ObservableProperty]
    private string? _email;


    /// <summary>
    /// Clears the current person details from the view.
    /// </summary>
    public void ClearPersonDetails()
    {
        SelectedPerson = null!;
    }

    /// <summary>
    /// Loads the person details based on the provided email.
    /// </summary>
    /// <param name="email">Email of the person to load.</param>
    [RelayCommand]
    public void LoadPerson(string email)
    {
        try
        {
            var person = _personRepository.GetPersonByEmail(email);
            if (person != null)
            {
                SelectedPerson = person;
                Email = string.Empty;
            }
            else
            {
                
                Debug.WriteLine("No person found with the given email.");
                Email = string.Empty;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error retrieving person: {ex.Message}");
            
        }
    }

    
}
