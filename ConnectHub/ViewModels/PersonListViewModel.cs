using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Interfaces;
using System;
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
            PersonList = new ObservableCollection<IPerson>(_personRepository.GetPersonsFromList());  
        };

        

    }

    [ObservableProperty]
    private ObservableCollection<IPerson> _personList = [];

    [RelayCommand]
    private async Task NavigateToEdit(IPerson updatedPerson)
    {
        var parameters = new ShellNavigationQueryParameters
        {
            {"Update", updatedPerson }
        };


        await Shell.Current.GoToAsync("UpdatePersonPage", parameters);
    }


    [RelayCommand]
    private async Task NavigateToAdd(IPerson person)
    {

        await Shell.Current.GoToAsync("AddPersonPage");
    }


    [RelayCommand]
    private async Task NavigateToShow(string email)
    {

        await Shell.Current.GoToAsync("ShowPersonPage");
    }


    [RelayCommand]
    private void Remove(string email)
    {
        _personRepository.RemovePersonFromList(email);
        PersonList = new ObservableCollection<IPerson>(_personRepository.GetPersonsFromList());
    }
}
