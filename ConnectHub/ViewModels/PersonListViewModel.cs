using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Interfaces;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace ConnectHub.ViewModels;


/// <summary>
/// ViewModel for managing and displaying a list of persons.
/// </summary>

public partial class PersonListViewModel : ObservableObject
{
    private readonly IPersonRepository _personRepository;

    /// <summary>
    /// Initializes a new instance of the PersonListViewModel class.
    /// </summary>
    /// <param name="personRepository">Repository for handling person data operations.</param>
    public PersonListViewModel(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
        LoadPersonsList(); 

        _personRepository.PersonsListUpdated += (sender, e) =>
        {
            
            LoadPersonsList(); 
        };
    }

    /// <summary>
    /// Collection of persons to be displayed.
    /// </summary>
    [ObservableProperty]
    private ObservableCollection<IPerson> _personsList = new ObservableCollection<IPerson>();

    /// <summary>
    /// Loads or reloads the list of persons from the repository.
    /// </summary>
    private void LoadPersonsList()
    {
        try
        {
            var newList = new ObservableCollection<IPerson>(_personRepository.GetPersonsFromList());
            PersonsList = newList;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error loading PersonList: {ex.Message}");
        }
    }



    /// <summary>
    /// Navigates to the edit page for a specified person.
    /// </summary>
    /// <param name="updatedPerson">The person to be edited.</param>
    [RelayCommand]
    private async Task NavigateToEdit(IPerson updatedPerson)
    {
        var parameters = new ShellNavigationQueryParameters
        {
            {"Update", updatedPerson }
        };


        await Shell.Current.GoToAsync("UpdatePersonPage", parameters);
    }

    /// <summary>
    /// Navigates to the add person page.
    /// </summary>
    [RelayCommand]
    private async Task NavigateToAdd(IPerson person)
    {

        await Shell.Current.GoToAsync("AddPersonPage");
    }

    /// <summary>
    /// Navigates to the show person page based on the given email.
    /// </summary>
    /// <param name="email">The email of the person to show.</param>
    [RelayCommand]
    private async Task NavigateToShow(string email)
    {

        await Shell.Current.GoToAsync("ShowPersonPage");
    }

    /// <summary>
    /// Removes a person from the list based on their email.
    /// </summary>
    /// <param name="email">The email of the person to remove.</param>
    [RelayCommand]
    private void Remove(string email)
    {
        _personRepository.RemovePersonFromList(email);
        LoadPersonsList();
    }
}
