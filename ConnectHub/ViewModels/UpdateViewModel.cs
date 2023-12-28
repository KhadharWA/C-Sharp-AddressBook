

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Interfaces;
using Shared.Models;
using Shared.Repositories;

namespace ConnectHub.ViewModels;

/// <summary>
/// ViewModel for updating a person's details.
/// </summary>
public partial class UpdateViewModel : ObservableObject, IQueryAttributable
{
    private readonly IPersonRepository _personRepository;

    /// <summary>
    /// Initializes a new instance of the UpdateViewModel class.
    /// </summary>
    /// <param name="personRepository">Repository for handling person data operations.</param>
    public UpdateViewModel(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    /// <summary>
    /// Holds the person details that are being updated.
    /// </summary>
    [ObservableProperty]
    private Person person = new();

    /// <summary>
    /// Updates the person's details in the repository and navigates back to the person list page.
    /// </summary>

    [RelayCommand]
    public async Task Update()
    {
        _personRepository.UpdatePerson(Person); 
        Person = new ();
        await Shell.Current.GoToAsync("//PersonsListPage");
    }

    /// <summary>
    /// Applies query attributes to the ViewModel.
    /// </summary>
    /// <param name="query">The query attributes to apply.</param>

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Person = (query["Update"] as Person)!;
    }
}
